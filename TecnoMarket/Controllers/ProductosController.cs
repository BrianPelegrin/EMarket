using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TecnoMarket.Core.Entities;
using TecnoMarket.Core.Interfaces;
using TecnoMarket.Core.ViewModels;

namespace TecnoMarket.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IRepository<Product> _product;
        private readonly IMapper _mapper;

        public ProductosController(IRepository<Product> product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var query = _product.GetAllWithInclude(x=>x.Category,x=>x.Statu);
            var modelMaped = _mapper.Map<IEnumerable<ProductViewModel>>(query);
            return View(modelMaped);
        }

        [HttpPost]
        public IActionResult ProductAdd(ProductViewModel product)
        {
            var modelMaped = _mapper.Map<Product>(product);
            _product.Save(modelMaped);
            return View();
        }

        [HttpDelete]
        public IActionResult ProductDelete(int Id)
        {
            var product = _product.Get(Id);
            if(product == null)
            {
                return NotFound();
            }
            _product.Delete(Id);
            return View();
        }

        [HttpPut]
        public IActionResult ProductUpdate(ProductViewModel product)
        {
            var modelMaped = _mapper.Map<Product>(product);
            _product.Save(modelMaped);
            return View();
        }
    }
}
