using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TecnoMarket.Core.Entities;
using TecnoMarket.Core.Interfaces;
using TecnoMarket.Infraestructure.Data;

namespace TecnoMarket.Infraestructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext _context;
        protected readonly DbSet<T> _entity;

        public Repository(ApplicationContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public T Delete(int id)
        {
            var entity = _entity.FirstOrDefault(x => x.Id == id);
            if (entity == null) return null;

            entity.StatuId = (int)EnumsStatus.Status.Inactive;
            _entity.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Get(int id)
        {
            var entity = _entity.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (entity == null) return null;

            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            var query = _entity.ToList();

            return query;
        }

        public IQueryable<T> GetAllWithInclude(params Expression<Func<T, object>>[] IncludeProperties)
        {
            IQueryable<T> query = _entity;

            foreach(var include in IncludeProperties)
            {
                query.Include(include);
            }

            return query.AsNoTracking();
        }

        public IQueryable<T> GetByIdWithInclude(int id,params Expression<Func<T, object>>[] IncludeProperties)
        {
            IQueryable<T> query = _entity;

            foreach (var include in IncludeProperties)
            {
                query.Include(include);
            }

            return query.AsNoTracking().Where(x=> x.Id == id);
        }

        public T Save(T entity)
        {
            if(entity.Id == 0)
            {
                entity.CreationDate = DateTime.Now;
                _entity.Add(entity);
            }
            else
            {
                entity.ModifiedDate = DateTime.Now;
                _entity.Update(entity);
            };

            _context.SaveChanges();
            return entity;
        }

    }
}
