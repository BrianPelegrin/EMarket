using Microsoft.AspNetCore.Mvc;

namespace TecnoMarket.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Checkout()
        {
            return View();
        }
    }
}
