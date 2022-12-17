using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TecnoMarket.Core.Interfaces;
using TecnoMarket.Core.Entities;
using TecnoMarket.Models;
using TecnoMarket.Extensions;
using TecnoMarket.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using TecnoMarket.Core.Entities.SecurityEntities;
using Microsoft.AspNetCore.Authorization;

namespace TecnoMarket.Controllers
{
    public class HomeController : BaseController<Category, HomeController>
    {
        private readonly IRepository<ProductPicture> _productPicture;
        private readonly IRepository<Product> _products;
        private readonly IRepository<ShoppingCart> _shoppingCart;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(IRepository<ProductPicture> productPicture, IRepository<Product> products, IRepository<ShoppingCart> shoppingCart, UserManager<ApplicationUser> userManager)
        {
            _productPicture = productPicture;
            _products = products;
            _shoppingCart = shoppingCart;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index(string SearchValue = null)
        {
            if (string.IsNullOrEmpty(SearchValue))
            {
                var query = _entity.GetAllWithInclude(x => x.Products.Where(x => x.StatuId != (int)EnumsStatus.Status.Inactive)).Where(x => x.StatuId != (int)EnumsStatus.Status.Inactive);
                var pictures = _productPicture.GetAll();
                var queryMapped = _mapper.Map<IEnumerable<CategoryViewModel>>(query);
                foreach (var productList in queryMapped.Select(x => x.Products))
                {
                    foreach (var product in productList)
                    {
                        product.Pictures = _mapper.Map<ICollection<ProductPictureViewModel>>(pictures.Where(x => x.ProductId == product.Id).ToList());
                    }
                }

                return View(queryMapped);
            }
            else
            {
                var query = _entity.GetAllWithInclude(x => x.Products.Where(x => x.StatuId != (int)EnumsStatus.Status.Inactive)).Where(x => x.StatuId != (int)EnumsStatus.Status.Inactive);
                var pictures = _productPicture.GetAll();
                var queryMapped = _mapper.Map<IEnumerable<CategoryViewModel>>(query);
                var lista = new List<ProductViewModel>();
                foreach (var productList in queryMapped.Select(x => x.Products))
                {
                    foreach (var product in productList)
                    {
                        product.Pictures = _mapper.Map<ICollection<ProductPictureViewModel>>(pictures.Where(x => x.ProductId == product.Id).ToList());
                    }
                }
                foreach(var product in queryMapped.Select(x=>x.Products))
                {
                    lista.AddRange(product.Where(x => x.Name.Contains(SearchValue)));
                }
                queryMapped.ForEach(x => x.Products = lista);
                return View(queryMapped);
            }
        }

        [HttpGet]
        public IActionResult ProductView(int id)
        {
            var query = _products.GetByIdWithInclude(id, x => x.Category, x => x.Pictures);
            var modelMaped = _mapper.Map<IEnumerable<ProductViewModel>>(query);
            return View(modelMaped);
        }

        [HttpPost]
        [Authorize]
        public async Task<bool> AddToCart([FromBody] AddToCartViewModel addToCartViewModel)
        {
            if (addToCartViewModel.ProductId > 0 && addToCartViewModel.Quantity > 0)
            {
                var user = await _userManager.FindByEmailAsync(_userManager.GetUserName(User));
                var result = new ShoppingCart { ProductId = addToCartViewModel.ProductId, Quantity = addToCartViewModel.Quantity, ApplicationUserId = user.Id, StatuId = (int)EnumsStatus.Status.Active };
                result = _shoppingCart.Save(result);

                if (result == null)
                {
                    BasicNotificaction(NotificationType.Error, "Ocurrio un Error");
                    return false;
                }
                else
                {
                    BasicNotificaction(NotificationType.Success, "Agregado Exitosamente");
                    return true;
                }
            }
            else
            {
                BasicNotificaction(NotificationType.Warning, "Algo No Salio Bien");
                return false;
            }

        }

    }
}