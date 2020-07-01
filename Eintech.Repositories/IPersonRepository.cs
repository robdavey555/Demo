using Eintech.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Eintech.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        IQueryable<Person> Search(Expression<Func<Person, bool>> filter);
    }
}