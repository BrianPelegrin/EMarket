using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TecnoMarket.Core.Entities;
using TecnoMarket.Core.Interfaces;
using TecnoMarket.Core.ViewModels;
using TecnoMarket.Extensions;
using TecnoMarket.Utils;

namespace TecnoMarket.Controllers
{

    public class ProductsController : BaseController<Product, ProductsController>
    {
        private readonly IRepository<Category> _categories;
        private readonly IRepository<ProductPicture> _productPictures;

        public ProductsController(IRepository<Category> categories, IRepository<ProductPicture> productPictures)
        {
            _categories = categories;
            _productPictures = productPictures;
        }

        [Authorize]
        [HttpGet]
        public IActionResult ProductList(string? ProductName = null)
        {
            var query = _entity.GetAllWithInclude(x => x.Category, x => x.Statu);
            if (ProductName != null)
            {
                query = query.Where(x => x.Name.Contains(ProductName));
            }
            var modelMaped = _mapper.Map<IEnumerable<ProductViewModel>>(query);
            return View(modelMaped);
        }

        [HttpGet]
        public IActionResult ProductView(int id)
        {
            var query = _entity.GetByIdWithInclude(id, x => x.Category, x => x.Pictures);
            var modelMaped = _mapper.Map<IEnumerable<ProductViewModel>>(query);
            return View(modelMaped);
        }

        [HttpGet]
        public IActionResult ProductAdd()
        {
            ViewData["SelectCategory"] = new SelectList(_categories.GetAll(), "Id", "Description");
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult ProductAdd(ProductViewModel product, IFormFileCollection PicturesList)
        {
           
            if (ModelState.IsValid)
            {
                var modelMaped = _mapper.Map<Product>(product);
                modelMaped.UserCreator = User.Identity.Name;
                var modelSaved = _entity.Save(modelMaped);
                if (modelSaved == null)
                {
                    BasicNotificaction(NotificationType.Error, "Ocurrio un error", "Ocurrio un Error al modificar el estado de el producto");
                    return View();
                }
                else
                {
                    if (PicturesList.Count > 0)
                    {
                        var images = ImageManager.ImageToBase64(PicturesList);
                        modelMaped.Pictures = ProductPictureManager(images, modelSaved.Id);
                        _entity.Save(modelMaped);
                    }
                    BasicNotificaction(NotificationType.Success, "Guardado Exitosamente");
                    return RedirectToAction("ProductList");
                }
            }
            else
            {
                ViewData["SelectCategory"] = new SelectList(_categories.GetAll(), "Id", "Description");
                return View();
            }
        }


        [HttpGet]
        public IActionResult ProductUpdate(int id)
        {
            ViewData["SelectCategory"] = new SelectList(_categories.GetAll(), "Id", "Description");
            var query = _entity.Get(id);
            var modelMaped = _mapper.Map<ProductViewModel>(query);
            return View(modelMaped);
        }

        [HttpPost]
        public IActionResult ProductUpdate(ProductViewModel product, IFormFileCollection PicturesList)
        {
            ViewData["SelectCategory"] = new SelectList(_categories.GetAll(), "Id", "Description");
            var modelMaped = _mapper.Map<Product>(product);
            var modelSaved = _entity.Save(modelMaped);
            if (modelSaved == null)
            {
                ViewData["SelectCategory"] = new SelectList(_categories.GetAll(), "Id", "Description");
                BasicNotificaction(NotificationType.Error, "Ocurrio un error", "Ocurrio un Error al modificar el estado de el producto");
                return View();
            }
            else
            {
                if (PicturesList.Count > 0)
                {
                    var picturesQuery = _productPictures.GetAll().Where(x => x.ProductId.Equals(modelSaved.Id)).Select(x => x.Image).ToList();
                    var images = ImageManager.ImageToBase64(PicturesList,picturesQuery);
                    modelMaped.Pictures = ProductPictureManager(images, modelSaved.Id);
                    _entity.Save(modelMaped);
                }
                BasicNotificaction(NotificationType.Success, "Guardado Exitosamente");
                return RedirectToAction("ProductList");
            }
        }

        [HttpDelete]
        public bool ProductDelete(int Id)
        {
            var product = _entity.Get(Id);
            if (product == null)
            {
                BasicNotificaction(NotificationType.Error, "Ocurrio un error", "Ocurrio un Error al modificar el estado de el producto");
                return false;
            }
            _entity.Delete(Id);
            BasicNotificaction(NotificationType.Success, "Modificacion Exitosa");
            return true;
        }

        private ICollection<ProductPicture> ProductPictureManager(List<string> images, int productId)
        {
            var pictures = new List<ProductPicture>();
            foreach (var item in images)
            {
                var photo = new ProductPictureViewModel
                {
                    Image = item,
                    ProductId = productId
                };
                pictures.Add(_mapper.Map<ProductPicture>(photo));
            }
            return pictures;
        }

    }
}
