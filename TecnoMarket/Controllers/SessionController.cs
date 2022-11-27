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
        public SessionController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
                
                var sesion = await _signInManager.PasswordSignInAsync(login.Email, login.Password, isPersistent: login.RememberMe, lockoutOnFailure: false);
                if (sesion.Succeeded)
                {

                    return RedirectToAction("Index", "Home");
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

        private void BasicNotificaction(NotificationType type, string title, string NotificationMessage = "")
            => TempData["notification"] = $"Swal.fire('{title}','{NotificationMessage}','{type.ToString().ToLower()}')";
    }
}
