using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
