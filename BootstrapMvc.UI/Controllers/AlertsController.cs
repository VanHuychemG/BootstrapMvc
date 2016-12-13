using BootstrapMvc.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BootstrapMvc.UI.Controllers
{
    public class AlertsController : BaseController
    {
        public IActionResult Index()
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
    }
}
