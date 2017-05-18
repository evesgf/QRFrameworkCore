using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCoreEF.Core
{
    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
