using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRepository.Services
{
    public class UserService:IUserService
    {
        public string Test()
        {
            return "Hello World!";
        }
    }
}
