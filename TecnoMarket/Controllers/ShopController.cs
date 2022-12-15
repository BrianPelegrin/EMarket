using Microsoft.AspNetCore.Mvc;

namespace TecnoMarket.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult ProductsToBuyList()
        {
            return View();
        }
    }
}
