using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCoreEF.Models;
using TestCoreEF.Repository;

namespace TestCoreEF.Services
{
    public class UserServcie:IUserService
    {
        public readonly IRepository<SYS_Model> _repository;

        public UserServcie(IRepository<SYS_Model> repository)
        {
            _repository = repository;
        }

        public string Test()
        {
            return "这是来自:" + _repository.Get(p=>p.UserName!=null).UserName;
        }
    }
}
