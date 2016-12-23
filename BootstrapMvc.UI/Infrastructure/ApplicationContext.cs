using System.Reflection;

using BootstrapMvc.UI.Infrastructure.Configuration;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BootstrapMvc.UI.Infrastructure
{
    public class ApplicationContext: IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.AddEntityConfigurationsFromAssembly(GetType().GetTypeInfo().Assembly);

            base.OnModelCreating(builder);
        }

        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
