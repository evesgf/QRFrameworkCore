using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TestAll.Services;

namespace TestAll.Dao
{
    public static class CommandHandlers
    {
        public static void AddCommandHandlers(this IServiceCollection services, params Assembly[] assemblies)
        {
            var serviceType = typeof(IDependencyRegister);

            //遍历子接口
            foreach (var service in assemblies.SelectMany(assembly => assembly.GetTypes()).Where(type => serviceType.IsAssignableFrom(type) && type.GetTypeInfo().IsAbstract))
            {
                if(service== serviceType) continue;

                //根据接口查找所有对应实例
                foreach (var implementationType in assemblies.SelectMany(assembly => assembly.GetTypes()).Where(type => service.IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract))
                {
                    services.AddTransient(service, implementationType);
                }
            }
        }
    }
}
