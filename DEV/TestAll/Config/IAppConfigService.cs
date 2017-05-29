using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAll.Config
{
    public interface IAppConfigService
    {
        T GetAppSettings<T>(string key) where T : class, new();
    }
}
