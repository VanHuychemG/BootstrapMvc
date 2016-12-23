using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BootstrapMvc.UI.Infrastructure
{
    public class ApplicationContextSeed
    {
        private readonly ApplicationContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ApplicationContextSeed> _logger;

        public ApplicationContextSeed(
            ApplicationContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<ApplicationContextSeed> logger)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task EnsureSeedAsync()
        {
            //  admin user
            var admin = await _userManager.FindByEmailAsync("admin@domain.com");
            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@domain.com"
                };

                /*  Keep in mind the password settings you set in Startup.cs

                    .AddIdentity<ApplicationUser, IdentityRole>(config =>
                    {
                        config.User.RequireUniqueEmail = true;
                        config.Password.RequiredLength = 6;
                        config.Password.RequireUppercase = false;
                        config.Password.RequireNonAlphanumeric = false;
                    })
                 */
                var result = await _userManager.CreateAsync(admin, "admin123");
                if (!result.Succeeded)
                    _logger.LogError(string.Join("\n", result.Errors.Select(e => $"{e.Code}: {e.Description}")));
            }

            //  user
            var user = await _userManager.FindByEmailAsync("user@domain.com");
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "user",
                    Email = "user@domain.com"
                };

                var result = await _userManager.CreateAsync(user, "user123");
                if (!result.Succeeded)
                    _logger.LogError(string.Join("\n", result.Errors.Select(e => $"{e.Code}: {e.Description}")));
            }

            //  roles
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
                await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
                await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
            }

            //  assign roles
            await _userManager.AddToRoleAsync(admin, "SuperAdmin");
            await _userManager.AddToRoleAsync(admin, "Admin");
            await _userManager.AddToRoleAsync(user, "User");

            _context.SaveChanges();
        }
    }
}
