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
                var user = await _userManager.FindByIdAsync(employee.Id);

                user.FullName = employee.FullName;
                user.PhoneNumber = employee.PhoneNumber;
                var creation = await _userManager.UpdateAsync(user);

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
        public async Task<IActionResult> ClientsList()
        {
            var users = new List<ApplicationUser>();
            var query = _userManager.Users.ToList();
            foreach (var user in query)
            {
                if (await _userManager.IsInRoleAsync(user, "User"))
                {
                    users.Add(user);
                }
            }
            return View(users);
        }

        [HttpGet]
        public IActionResult ClientsEdit(string Id)
        {
            return View(_userManager.Users.FirstOrDefault(x=>x.Id.Equals(Id)));
        }

        [HttpPost]
        public async Task<IActionResult> ClientsEdit(ApplicationUser client)
        {
            var user = await _userManager.FindByIdAsync(client.Id);

            user.FullName = client.FullName;
            user.PhoneNumber = client.PhoneNumber;
            var creation = await _userManager.UpdateAsync(user);

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


        [HttpGet]
        public async Task< IActionResult> ProfileEdit()
        {
            return View(await _userManager.GetUserAsync(User));
        }

        [HttpPost]
        public async Task<IActionResult> ProfileEdit(ApplicationUser profile)
        {
            var user = await _userManager.FindByIdAsync(profile.Id);

            user.FullName = profile.FullName;
            user.PhoneNumber = profile.PhoneNumber;
            var creation = await _userManager.UpdateAsync(user);

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
    }
}
