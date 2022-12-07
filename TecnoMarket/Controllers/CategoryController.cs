using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TecnoMarket.Core.Entities;
using TecnoMarket.Core.ViewModels;
using TecnoMarket.Extensions;

namespace TecnoMarket.Controllers
{
        [Authorize]
    public class CategoryController : BaseController<Category, CategoryController>
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            var query = _entity.GetAllWithInclude(x=>x.Products,x=>x.Statu);
            var modelMaped = _mapper.Map<IEnumerable<CategoryViewModel>>(query);
            return View(modelMaped);
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(CategoryViewModel Category)
        {
            var modelMaped = _mapper.Map<Category>(Category);
            var modelSaved = _entity.Save(modelMaped);
            if (modelSaved == null)
            {
                BasicNotificaction(NotificationType.Error, "Ocurrio un error", "Ocurrio un Error al guardar la categoria");
                return View();
            }
            BasicNotificaction(NotificationType.Success, "Guardado Exitosamente");
            Thread.Sleep(100);
            return RedirectToAction(nameof(CategoryList));
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

        [HttpGet]
        public IActionResult CategoryUpdate(int id)
        {
            var query = _mapper.Map<CategoryViewModel>(_entity.Get(id));
            return View(query);
        }

        [HttpPost]
        public IActionResult CategoryUpdate(CategoryViewModel Category)
        {
            var modelMaped = _mapper.Map<Category>(Category);
            var modelSaved = _entity.Save(modelMaped);
            if (modelSaved == null)
            {
                BasicNotificaction(NotificationType.Error, "Ocurrio un error", "Ocurrio un Error al actualizar la categoria");
                return View();
            }
            BasicNotificaction(NotificationType.Success, "Actualizada Exitosamente");
            Thread.Sleep(100);
            return RedirectToAction(nameof(CategoryList));
        }
    }
}
