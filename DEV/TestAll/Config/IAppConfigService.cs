using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAll.Services;

namespace TestAll.Config
{
    public interface IAppConfigService: IDependencyRegister
    {
        T GetAppSettings<T>(string key) where T : class, new();
    }
}
