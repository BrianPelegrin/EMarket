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
            var transactions = new List<Transaction>();
            var transactionId = Guid.NewGuid();
            foreach (var article in _entity.GetAllWithInclude(x=>x.Product, x=>x.ApplicationUser).Where(x=>x.ApplicationUserId.Equals(user.Id)).ToList())
            {
                transactions.Add(new Transaction { ProductId = article.Id, ApplicationUserId = user.Id, TransactionIdentifier = transactionId });
                _entity.DeletePermanent(article.Id);
               //transactions.Add(_transactions.Save(new Transaction { ProductId = article.Id, ApplicationUserId = user.Id, TransactionIdentifier = Guid.NewGuid() }));
            }
            BasicNotificaction(NotificationType.Success,"Compra Exitosa");
            return RedirectToAction("Index","Hombe");
        }

        [HttpGet]
        public IActionResult Receipt(List<Transaction> transactions)
        {
            return View(transactions);
        }

    }
}
