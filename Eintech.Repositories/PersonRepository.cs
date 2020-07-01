using Eintech.Data;
using Eintech.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace Eintech.Repositories
{
    [ExcludeFromCodeCoverage]
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(EintechContext context) : base(context) { }

        public IQueryable<Person> Search(Expression<Func<Person, bool>> filter)
        {
            var dbSet = GetAll(filter, d => d.Group);

            return dbSet.AsQueryable();
        }
    }
}
