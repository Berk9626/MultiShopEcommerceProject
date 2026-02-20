using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Web.UI.ViewComponents.ProductListViewComponent
{
    public class _ProductListPagingComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
