using BootstrapMvc.Core.Controllers;
using BootstrapMvc.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BootstrapMvc.UI.Controllers
{
    public class FormsController: BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BootstrapValidationStyle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BootstrapValidationStyle(AddressViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Success("Hooray!");

                return View(viewModel);
            }

            Danger("Looks like something went wrong. Please check your form.");

            return View(viewModel);
        }

        public IActionResult Localized()
        {
            return View();
        }
    }
}
