using System.Threading.Tasks;

using BootstrapMvc.UI.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace BootstrapMvc.UI.ViewComponents
{
    public class Order : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(OrderViewModel order)
        {
            return View("Order", await Task.FromResult(order));
        }
    }
}
