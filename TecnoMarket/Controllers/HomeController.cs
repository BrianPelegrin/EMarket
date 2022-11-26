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

        public IActionResult Index()
        {
            var query = _entity.GetAllWithInclude(x => x.Products);
            var queryMapped = _mapper.Map<IEnumerable<CategoryViewModel>>(query);
            return View(queryMapped);
        }

    }
}