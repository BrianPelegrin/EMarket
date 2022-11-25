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
            @ViewData["ValidacionGroup"] = string.Empty;
            @ViewData["ValidacionInput"] = string.Empty;
            @ViewData["ValidacionSpan"] = string.Empty;
            if (ModelState.IsValid)
            {
                
                var sesion = await _signInManager.PasswordSignInAsync(login.Email, login.Password, isPersistent: false, lockoutOnFailure: false);
                if (sesion.Succeeded)
                {
                    @ViewData["ValidacionGroup"] = "has-success";
                    @ViewData["ValidacionInput"] = "is-valid";
                    @ViewData["ValidacionSpan"] = "valid-feedback";
                    Thread.Sleep(5000);

                    return RedirectToAction("Index", "Home");
                }
                @ViewData["ValidacionGroup"] = "has-danger";
                @ViewData["ValidacionInput"] = "is-invalid";
                @ViewData["ValidacionSpan"] = "invalid-feedback";
            }
            else
            {
                @ViewData["ValidacionGroup"] = "has-danger";
                @ViewData["ValidacionInput"] = "is-invalid";
                @ViewData["ValidacionSpan"] = "invalid-feedback";

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
                    @ViewData["ValidacionGroup"] = "has-success";
                    @ViewData["ValidacionInput"] = "is-valid";
                    @ViewData["ValidacionSpan"] = "valid-feedback";
                    Thread.Sleep(5000);

                    return RedirectToAction(nameof(Login));
                }
            }
            else
            {
                @ViewData["ValidacionGroup"] = "has-danger";
                @ViewData["ValidacionInput"] = "is-invalid";
                @ViewData["ValidacionSpan"] = "invalid-feedback";

            }

            return View();

        }
    }
}
