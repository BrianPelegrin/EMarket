using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TecnoMarket.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public IQueryable<T> GetAllWithInclude(params Expression<Func<T,object>>[] IncludeProperties);
        public T Get(int id);
        public IQueryable<T> GetByIdWithInclude(int id,params Expression<Func<T, object>>[] IncludeProperties);
        public T Save(T entity);
        public T Delete(int id);


    }
}
