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
            var serviceType = typeof(IUserService);

            foreach (var implementationType in assemblies.SelectMany(assembly => assembly.GetTypes()).Where(type => serviceType.IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract))
            {
                services.AddTransient(serviceType, implementationType);
            }
        }
    }
}
