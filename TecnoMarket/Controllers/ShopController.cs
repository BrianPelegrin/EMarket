using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TecnoMarket.Core.Entities;
using TecnoMarket.Core.Entities.SecurityEntities;
using TecnoMarket.Core.Interfaces;
using TecnoMarket.Core.ViewModels;
using TecnoMarket.Extensions;

namespace TecnoMarket.Controllers
{
    [Authorize]
    public class ShopController : BaseController<ShoppingCart,ShopController>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<Transaction> _transactions;

        public ShopController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IRepository<Transaction> transactions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _transactions = transactions;
        }
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.GetUserAsync(User);
            var query = _mapper.Map<List<ShoppingCartViewModel>>(_entity.GetAllWithInclude(x=>x.Product).Where(x=>x.ApplicationUserId.Equals(user.Id)).ToList());
            return View(query);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(string id = null)
        {

            var user = await _userManager.GetUserAsync(User);

            foreach (var article in _entity.GetAllWithInclude(x=>x.Product, x=>x.ApplicationUser).Where(x=>x.ApplicationUserId.Equals(user.Id)).ToList())
            {
                var product = _entity.Get(article.Id);
                product.StatuId = (int)EnumsStatus.Status.Inactive;
                _entity.Save(product);
            }
            return RedirectToAction("Receipt");
        }

        [HttpGet]
        public async Task<IActionResult> Receipt()
        { 
            var user = await _userManager.GetUserAsync(User);
            var shopCart = _mapper.Map<List<ShoppingCartViewModel>>(_entity.GetAllWithInclude(x => x.Product.Category, x => x.Product.Pictures).Where(x => x.ApplicationUserId.Equals(user.Id)).ToList());
            return View(shopCart);
        }

    }
}
