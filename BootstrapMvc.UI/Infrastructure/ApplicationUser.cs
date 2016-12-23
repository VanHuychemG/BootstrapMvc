using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BootstrapMvc.UI.Infrastructure
{
    public class ApplicationUser: IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
