using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TecnoMarket.Core.Entities;
using TecnoMarket.Extensions;

namespace TecnoMarket.Controllers
{
    [Authorize]
    public class UsersController : BaseController<Product,UsersController>
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
