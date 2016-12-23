using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

namespace BootstrapMvc.UI.Infrastructure
{
    public interface IApplicationRepository
    {
        Task<bool> SaveChangesAsync();
    }

    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<ApplicationRepository> _logger;

        public ApplicationRepository(
            ApplicationContext context,
            ILogger<ApplicationRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
