using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TecnoMarket.Core.Entities.SecurityEntities;
using TecnoMarket.Core.ViewModels;

namespace TecnoMarket.Controllers
{
    public class SessionController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SessionController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Login()
        {

           return View();
            
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {

            if (ModelState.IsValid)
            {
                
                var sesion = await _signInManager.PasswordSignInAsync(login.Email, login.Password, isPersistent: login.RememberMe, lockoutOnFailure: true);
                if (sesion.Succeeded)
                {

                    return RedirectToAction("Index", "Home");
                }
                if (sesion.IsLockedOut || _userManager.FindByEmailAsync(login.Email).Result.LockoutEnabled)
                {
                    BasicNotificaction(NotificationType.Error, "Usuario Bloqueado", "El Usuario se ha bloqueado temporalmente por exceso de intentos fallidos");
                }
                else
                {
                    BasicNotificaction(NotificationType.Error, "Credenciales Invalidas", "El Usuario o la Contraseña son incorrectos");
                }

            }

            return View();

        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationViewModel register)
        {
            if (ModelState.IsValid)
            {
                if(!await _roleManager.RoleExistsAsync("Admin"))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
                }
                if (!await _roleManager.RoleExistsAsync("Employee"))
                { 
                    await _roleManager.CreateAsync(new IdentityRole { Name = "Employee" });  
                }
                if (!await _roleManager.RoleExistsAsync("User"))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
                }

                var user = new ApplicationUser
                {
                    UserName = register.Email,
                    Email = register.Email,
                    PhoneNumber = register.PhoneNumber,
                    FullName = register.FullName
                };
                var creation = await _userManager.CreateAsync(user, register.Password);
                if (creation.Succeeded)
                {
                    var userCreated = await _userManager.FindByEmailAsync(user.Email);
                    if(_userManager.Users.Count() <= 1)
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }
                    BasicNotificaction(NotificationType.Success, "Registro Exitoso");
                    return RedirectToAction(nameof(Login));
                }
                
            }

            return View();

        }

        [HttpPost]
        public async void Logout()
        {
             await _signInManager.SignOutAsync();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string Email)
        {
            BasicNotificaction(NotificationType.Success,"Correo Enviado Exitosamente","Se Envio un correo para que pueda restablecer su contraseña");
            Thread.Sleep(1000);
            return View("Login");
        }

        private void BasicNotificaction(NotificationType type, string title, string NotificationMessage = "")
            => TempData["notification"] = $"Swal.fire('{title}','{NotificationMessage}','{type.ToString().ToLower()}')";
    }
}
