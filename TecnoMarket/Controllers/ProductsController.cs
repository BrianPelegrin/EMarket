using Microsoft.AspNetCore.Mvc;
using TecnoMarket.Core.Entities;
using TecnoMarket.Core.ViewModels;
using TecnoMarket.Extensions;

namespace TecnoMarket.Controllers
{
    public class ProductsController : BaseController<Product, ProductsController>
    {
        
        [HttpGet]
        public IActionResult ProductList()
        {
            var query = _entity.GetAllWithInclude(x=>x.Category,x=>x.Statu);
            var modelMaped = _mapper.Map<IEnumerable<ProductViewModel>>(query);
            return View(modelMaped);
        }

        [HttpGet]
        public IActionResult ProductView(int id)
        {
            var query = _entity.GetByIdWithInclude(id, x=> x.Category);
            var modelMaped = _mapper.Map<IEnumerable<ProductViewModel>>(query);
            return View(modelMaped);
        }

        [HttpPost]
        public IActionResult ProductAdd(ProductViewModel product)
        {
            var modelMaped = _mapper.Map<Product>(product);
            _entity.Save(modelMaped);
            return View();
        }

        [HttpDelete]
        public bool ProductDelete(int Id)
        {
            var product = _entity.Get(Id);
            if(product == null)
            {
                BasicNotificaction(NotificationType.Error, "Ocurrio un error", "Ocurrio un Error al modificar el estado de el producto");
                return false;
            }
            _entity.Delete(Id);
            BasicNotificaction(NotificationType.Success, "Modificacion Exitosa");
            return true;
        }

        [HttpPut]
        public IActionResult ProductUpdate(ProductViewModel product)
        {
            var modelMaped = _mapper.Map<Product>(product);
            _entity.Save(modelMaped);
            return View();
        }
    }
}
