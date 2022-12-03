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

        public HomeController(IRepository<ProductPicture> productPicture)
        {
            _productPicture = productPicture;
        }

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

    }
}