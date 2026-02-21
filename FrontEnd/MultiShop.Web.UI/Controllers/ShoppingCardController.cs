using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Web.UI.Controllers
{
    public class ShoppingCardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
