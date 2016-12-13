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

        [HttpPost]
        [ValidateAntiForgeryToken, ActionName("Index")]
        public IActionResult Edit(AddressViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Success("Hooray!");

                return View(viewModel);
            }

            Danger("Looks like something went wrong. Please check your form.");

            return View(viewModel);
        }
    }
}
