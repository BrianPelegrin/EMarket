using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TecnoMarket.Core.Entities;
using TecnoMarket.Core.Interfaces;

namespace TecnoMarket.Extensions
{
    public abstract class BaseController<TEntity,TController> : Controller where TEntity : BaseEntity where TController : Controller
    {
        #region DependencyInjection

        private readonly IRepository<TEntity> entity;
        protected IRepository<TEntity> _entity => entity ?? (HttpContext.RequestServices.GetService<IRepository<TEntity>>());


        private readonly IMapper mapper;
        protected IMapper _mapper => mapper ?? (HttpContext.RequestServices.GetService<IMapper>());

        #endregion

        #region NotificationSection

        protected void BasicNotificaction(NotificationType type, string title, string NotificationMessage = "")
            => TempData["notification"] = $"Swal.fire('{title}','{NotificationMessage}','{type.ToString().ToLower()}')";

        #endregion

        #region
        protected void BasicModal(string viewName, string modalTitle)
        {
            TempData["BasicModal"] = $"$('#ModalBody').load('{viewName}')"; 
            ViewData["ModalTitle"] = modalTitle;
        }
             
        #endregion
    }
}
