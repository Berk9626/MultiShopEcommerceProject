using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Web.UI.ViewComponents.ShoppingCardViewComponents
{
    public class _ShoppingCardProductListComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
