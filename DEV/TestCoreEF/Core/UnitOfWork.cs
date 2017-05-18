using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCoreEF.Dao;

namespace TestCoreEF.Core
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private TestDBContext _context;

        public UnitOfWork(TestDBContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
