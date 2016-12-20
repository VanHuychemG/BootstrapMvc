using System;
using System.IO;
using BootstrapMvc.Core.Controllers;
using BootstrapMvc.UI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace BootstrapMvc.UI.Controllers
{
    public class FormsController : BaseController
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

        public IActionResult LocalizedForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LocalizedForm(OrderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Success("Hooray!");

                return View(viewModel);
            }

            Danger("Looks like something went wrong. Please check your form.");

            return View(viewModel);
        }

        public IActionResult UploadAndDisplayImage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UploadAndDisplayImage(IFormFile file)
        {
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue
                    .Parse(file.ContentDisposition)
                    .FileName
                    .Trim('"');

                using (var fs = file.OpenReadStream())
                {
                    using (var ms = new MemoryStream())
                    {
                        fs.CopyTo(ms);

                        var fileBytes = ms.ToArray();

                        var s =
                            $"data:image/{Path.GetExtension(fileName).Substring(1)};base64,{Convert.ToBase64String(fileBytes)}";

                        //  save the image to the db
                        //  ...

                        Success("Hooray!");

                        return View(new ImageViewModel
                        {
                            Base64 = s
                        });
                    }
                }
            }

            Danger("Looks like something went wrong. Please check your form.");

            return View();
        }

        public IActionResult ShowHidePassword()
        {
            return View();
        }
    }
}
