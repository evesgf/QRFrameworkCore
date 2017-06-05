using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestAll.Services;

namespace TestAll.Resposity
{
    public interface IRepository<T> where T:class
    {
        bool Save(T entity, bool isCommit = true);
        bool Update(T entity, bool isCommit = true);
        T Get(Expression<Func<T, bool>> predicate);
        bool Delete(T entity, bool isCommit = true);
    }
}
