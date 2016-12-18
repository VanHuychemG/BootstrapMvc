using System.Threading.Tasks;

using BootstrapMvc.UI.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace BootstrapMvc.UI.ViewComponents
{
    public class ImageUpload : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ImageViewModel image)
        {
            return View("ImageUpload", await Task.FromResult(image));
        }
    }
}
