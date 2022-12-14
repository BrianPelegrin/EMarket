using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TecnoMarket.Core.Entities;
using TecnoMarket.Extensions;

namespace TecnoMarket.Controllers
{
    [Authorize]
    public class RolesController : BaseController<Product,RolesController>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult RolesList()
        {
            BasicModal("RolesAdd", "Formulario de Roles");
            var query = _roleManager.Roles.ToList();
            return View(query);
        }

        [HttpGet]
        public IActionResult RolesAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RolesAdd(IdentityRole role)
        {
            return View(role);
        }

        [HttpGet]
        public IActionResult RolesUpdate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RolesUpdate(IdentityRole role)
        {
            return View(role);
        }

        [HttpPost]
        public IActionResult RolesDelete(IdentityRole role)
        {
            return View(role);
        }

    }
}
