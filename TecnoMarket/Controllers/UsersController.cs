using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TecnoMarket.Core.Entities;
using TecnoMarket.Core.Entities.SecurityEntities;
using TecnoMarket.Core.ViewModels;
using TecnoMarket.Extensions;

namespace TecnoMarket.Controllers
{
    [Authorize]
    public class UsersController : BaseController<Product,UsersController>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeList()
        {
            var users = new List<ApplicationUser>();
            var query = _userManager.Users.ToList();
            foreach(var user in query)
            {
                if( await _userManager.IsInRoleAsync(user, "Employee"))
                {
                    users.Add(user);
                }
            }
            return View(users);
        }

        [HttpGet]
        public IActionResult EmployeeAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeAdd(UserRegistrationViewModel employee)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = employee.Email,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    FullName = employee.FullName
                };
                var creation = await _userManager.CreateAsync(user, employee.Password);
                if (creation.Succeeded)
                {
                    var userCreated = await _userManager.FindByEmailAsync(user.Email);
                
                    await _userManager.AddToRoleAsync(user, "Employee");
                
                    BasicNotificaction(NotificationType.Success, "Registro Exitoso");
                    return RedirectToAction(nameof(EmployeeList));
                }
                else
                {
                    BasicNotificaction(NotificationType.Success,"Ocurrio un Error al Registrar");
                    return View();
                }

            }
            return View();
        }


        [HttpGet]
        public IActionResult EmployeeEdit(string Id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id.Equals(Id));
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeEdit(ApplicationUser employee)
        {
            if (ModelState.IsValid)
            {
                               var creation = await _userManager.UpdateAsync(employee);
                if (creation.Succeeded)
                {

                    BasicNotificaction(NotificationType.Success, "Actualizacion Exitosa");
                    return RedirectToAction(nameof(EmployeeList));
                }
                else
                {
                    BasicNotificaction(NotificationType.Success, "Ocurrio un Error al Actualizar");
                    return View();
                }

            }
            return View();
        }

        [HttpDelete]
        public async Task<bool> LockEmployee(string Id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id.Equals(Id));
            user.LockoutEnabled = user.LockoutEnabled ? false : true;
           var results = await _userManager.UpdateAsync(user);
            if (results.Succeeded)
            {
                BasicNotificaction(NotificationType.Success,"Se Modifico el estado Exitosamente");
            return true;
            }
            else
            {
                BasicNotificaction(NotificationType.Error, "Ocurrio un Error");
                return false;
            }
        }


        [HttpGet]
        public IActionResult ClientsList()
        {
            var query = _userManager.Users.ToList().Where(x => _userManager.IsInRoleAsync(x, "User").Result);
            return View(query);
        }

        [HttpGet]
        public IActionResult ClientsEdit(string Id)
        {
            return View(_userManager.Users.FirstOrDefault(x=>x.Id.Equals(Id)));
        }

        [HttpPost]
        public IActionResult ClientsEdit(ApplicationUser client)
        {
            var query = _userManager.Users.ToList().Where(x => _userManager.IsInRoleAsync(x, "User").Result);
            BasicNotificaction(NotificationType.Success, "Registro Exitoso");
            return View("ClientsList");
        }


        [HttpGet]
        public IActionResult ProfileEdit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProfileEdit(ApplicationUser profile)
        {
            var query = _userManager.GetUserAsync(User).Result;
            BasicNotificaction(NotificationType.Success, "Registro Exitoso");
            return View("ClientsList");
        }
    }
}
