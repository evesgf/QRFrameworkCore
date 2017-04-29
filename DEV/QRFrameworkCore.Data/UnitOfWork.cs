using System;
using System.Collections.Generic;
using System.Text;

namespace QRFrameworkCore.Data
{
    public class UnitOfWork: IUnitOfWork,IDisposable
    {
        public bool Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
