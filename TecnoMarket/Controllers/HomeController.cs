using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TecnoMarket.Core.Interfaces;
using TecnoMarket.Core.Entities;
using TecnoMarket.Models;
using TecnoMarket.Extensions;
using TecnoMarket.Core.ViewModels;

namespace TecnoMarket.Controllers
{
    public class HomeController : BaseController<Category, HomeController>
    {
        private readonly IRepository<ProductPicture> _productPicture;
        private readonly IRepository<Product> _products;

        public HomeController(IRepository<ProductPicture> productPicture, IRepository<Product> products)
        {
            _productPicture = productPicture;
            _products = products;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var query = _entity.GetAllWithInclude(x => x.Products.Where(x => x.StatuId != (int)EnumsStatus.Status.Inactive)).Where(x=>x.StatuId != (int)EnumsStatus.Status.Inactive);
            var pictures = _productPicture.GetAll();
            var queryMapped = _mapper.Map<IEnumerable<CategoryViewModel>>(query);
            foreach(var productList in queryMapped.Select(x => x.Products))
            {
                foreach(var product in productList)
                {
                    product.Pictures = _mapper.Map<ICollection<ProductPictureViewModel>>(pictures.Where(x=>x.ProductId ==  product.Id).ToList());
                }
            }
            return View(queryMapped);
        }

        [HttpGet]
        public IActionResult ProductView(int id)
        {
            var query = _products.GetByIdWithInclude(id, x => x.Category, x => x.Pictures);
            var modelMaped = _mapper.Map<IEnumerable<ProductViewModel>>(query);
            return View(modelMaped);
        }

    }
}