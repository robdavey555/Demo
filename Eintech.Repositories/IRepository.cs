using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Eintech.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] children);
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] children);
        
        Task<T> Find(Guid id);

        IQueryable<T> AllAsNoTracking();

        void Add(T entity);
    }
}