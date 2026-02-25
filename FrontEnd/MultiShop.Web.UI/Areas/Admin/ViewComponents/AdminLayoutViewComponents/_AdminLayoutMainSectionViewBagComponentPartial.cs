using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Web.UI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutMainSectionViewBagComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
