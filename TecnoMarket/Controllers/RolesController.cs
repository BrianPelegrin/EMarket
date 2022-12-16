using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TecnoMarket.Core.Entities;
using TecnoMarket.Extensions;

namespace TecnoMarket.Controllers
{
    [Authorize]
    public class RolesController : BaseController<Product, RolesController>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // OBTENER LOS ROLES.
        [HttpGet]
        public IActionResult RolesList()
        {
            BasicModal("RolesAdd", "Formulario de Roles");
            var query = _roleManager.Roles.ToList();
            return View(query);
        }

        // VISTA PARA AGREGAR ROLES.
        [HttpGet]
        public IActionResult RolesAdd()
        {
            return View();
        }

        // ENVIAR ROLES.
        [HttpPost]
        public IActionResult RolesAdd(IdentityRole role)
        {
            return View(role);
        }

        // VISTA PARA ACTUALIZAR ROLES.
        [HttpGet]
        public IActionResult RolesUpdate()
        {
            return View();
        }

        // ACTUALIZAR ROL.
        [HttpPost]
        public IActionResult RolesUpdate(IdentityRole role)
        {
            return View(role);
        }

        // ELIMINAR ROL.
        [HttpPost]
        public IActionResult RolesDelete(IdentityRole role)
        {
            return View(role);
        }

    }
}
