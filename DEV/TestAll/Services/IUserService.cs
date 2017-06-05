using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestAll.Entitys;

namespace TestAll.Services
{
    public interface IUserService : IDependencyRegister
    {
        string TestService();

        string Test2();
    }
}
