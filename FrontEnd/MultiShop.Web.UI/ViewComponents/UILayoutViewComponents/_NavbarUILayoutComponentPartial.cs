using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Web.UI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
