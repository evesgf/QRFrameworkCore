using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace TestAll.Config
{
    public class AppConfigService: IAppConfigService
    {
        public T GetAppSettings<T>(string key) where T : class, new()
        {
            var config = new ConfigurationBuilder().Add(new JsonConfigurationSource {Path = "Config/SiteConfig.json" }).Build();

            var appConfig = new ServiceCollection().AddOptions().Configure<T>(config.GetSection(key))
                .BuildServiceProvider().GetService<IOptions<T>>().Value;

            return appConfig;
        }
    }
}
