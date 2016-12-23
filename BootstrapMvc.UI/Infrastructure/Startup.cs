using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;

namespace BootstrapMvc.UI.Infrastructure
{
    public class Startup
    {
        private IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true)
                .AddEnvironmentVariables();

            // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
            });

            services
                .AddEntityFrameworkMySql()
                .AddDbContext<ApplicationContext>(db =>
                {
                    db.UseMySql(Configuration.GetConnectionString("ApplicationConnection"));
                });

            services
                .AddIdentity<ApplicationUser, IdentityRole>(config =>
                {
                    config.User.RequireUniqueEmail = true;
                    config.Password.RequiredLength = 6;
                    config.Password.RequireUppercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores <ApplicationContext>()
                .AddDefaultTokenProviders();

            services
                .AddScoped<IApplicationRepository, ApplicationRepository>()
                .AddTransient<ApplicationContextSeed>();

            services
                .AddLogging();

            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("PrivateCache",
                     new Microsoft.AspNetCore.Mvc.CacheProfile
                     {
                         Duration = 60,
                         Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.None
                     });
                options.CacheProfiles.Add("PublicCache",
                    new Microsoft.AspNetCore.Mvc.CacheProfile
                    {
                        Duration = 86400,
                        Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.Client
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            ApplicationContextSeed seeder)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var migratorOptions = new DbContextOptionsBuilder<ApplicationContext>()
                .UseMySql(Configuration.GetConnectionString("ApplicationConnection"))
                .UseLoggerFactory(loggerFactory)
                .Options;

            using (var migrator = new ApplicationContext(migratorOptions))
                migrator.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 60 * 24;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=" + durationInSeconds;
                }
            });

            app.UseIdentity();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            await seeder.EnsureSeedAsync();
        }
    }
}
