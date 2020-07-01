using Eintech.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Eintech.Repositories
{
    [ExcludeFromCodeCoverage]
    public class BaseRepository<T> : IRepository<T>
        where T : class
    {
        protected readonly EintechContext _context;

        public BaseRepository(EintechContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<T> AllAsNoTracking() => _context.Set<T>().AsNoTracking();

        public async Task<T> Find(Guid id) => await _context.Set<T>().FindAsync(id);

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] children)
        {
            var dbSet = _context.Set<T>();
            children.ToList().ForEach(x => dbSet.Include(x).Load());
            return dbSet.AsQueryable();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] children)
        {
            var dbSet = _context.Set<T>();
            children.ToList().ForEach(x => dbSet.Include(x).Load());

            return dbSet.Where(filter).AsQueryable();
        }

        public void Add(T entity)
        {
            _context.Set<T>().AddAsync(entity);

            _context.SaveChanges();
        }
    }
}