using System.Threading.Tasks;

using BootstrapMvc.UI.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace BootstrapMvc.UI.ViewComponents
{
    public class Address : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(AddressViewModel address)
        {
            return View("Address", await Task.FromResult(address));
        }
    }
}
