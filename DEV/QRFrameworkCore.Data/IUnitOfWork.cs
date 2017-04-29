using System;
using System.Collections.Generic;
using System.Text;

namespace QRFrameworkCore.Data
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
