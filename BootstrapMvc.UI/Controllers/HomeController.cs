using BootstrapMvc.Core.Controllers;

using Microsoft.AspNetCore.Mvc;

namespace BootstrapMvc.UI.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Alerts()
        {
            ViewData["Message"] = "Samples of alert messages.";

            Information("Fading information message.");
            Information("Dismissable information message.", true);

            Warning("Fading warning message.");
            Warning("Dismissable warning message.", null, true);

            Danger("Fading danger message.");
            Danger("Dismissable danger message", null, true);

            Success("Fading success message.");
            Success("Dismissable success message.", true);

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
