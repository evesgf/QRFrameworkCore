using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAll.Dao;

namespace TestAll.Resposity
{
    public abstract class Repository<T>:IRepository<T> where T:class
    {
        private TestAllDbContext _context;
        private UnitOfWork _unitOfWork;

        public Repository(TestAllDbContext context)
        {
            _context = context;
            _unitOfWork=new UnitOfWork(_context);
        }

        public bool Save(T entity, bool isCommit = true)
        {
            _context.Add(entity);

            return isCommit && _unitOfWork.Commit();
        }

        public bool Update(T entity, bool isCommit = true)
        {
            _context.Attach(entity);
            _context.Entry(entity).State=EntityState.Modified;

            return isCommit && _unitOfWork.Commit();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().SingleOrDefault(predicate);
        }

        public bool Delete(T entity, bool isCommit = true)
        {
            if (entity == null) return false;

            _context.Remove(entity);

            return isCommit && _unitOfWork.Commit();
        }
    }
}
