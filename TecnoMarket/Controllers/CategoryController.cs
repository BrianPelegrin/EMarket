using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TecnoMarket.Core.Entities;
using TecnoMarket.Core.ViewModels;
using TecnoMarket.Extensions;

namespace TecnoMarket.Controllers
{
    public class CategoryController : BaseController<Category, CategoryController>
    {
        [Authorize]
        [HttpGet]
        public IActionResult CategoryList()
        {
            var query = _entity.GetAllWithInclude(x=>x.Products,x=>x.Statu);
            var modelMaped = _mapper.Map<IEnumerable<CategoryViewModel>>(query);
            return View(modelMaped);
        }

        [HttpPost]
        public IActionResult CategoryAdd(CategoryViewModel Category)
        {
            var modelMaped = _mapper.Map<Category>(Category);
            _entity.Save(modelMaped);
            return View();
        }

        [HttpDelete]
        public bool CategoryDelete(int Id)
        {
            var Category = _entity.Get(Id);
            if(Category == null)
            {
                BasicNotificaction(NotificationType.Error, "Ocurrio un error","Ocurrio un Error al modificar el estado de la categoria");
                return false;
            }
            _entity.Delete(Id);
            BasicNotificaction(NotificationType.Success, "Modificacion Exitosa");
            return true;
        }

        [HttpPut]
        public IActionResult CategoryUpdate(CategoryViewModel Category)
        {
            var modelMaped = _mapper.Map<Category>(Category);
            _entity.Save(modelMaped);
            return View();
        }
    }
}
