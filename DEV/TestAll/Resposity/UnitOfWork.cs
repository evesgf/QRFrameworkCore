using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAll.Dao;

namespace TestAll.Resposity
{
    public class UnitOfWork:IUnitOfWork,IDisposable
    {
        private TestAllDbContext _context;

        public UnitOfWork(TestAllDbContext context)
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
