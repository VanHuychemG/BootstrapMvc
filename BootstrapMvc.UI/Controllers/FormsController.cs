using Microsoft.AspNetCore.Mvc;

namespace BootstrapMvc.UI.Controllers
{
    public class FormsController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken, ActionName("Index")]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
