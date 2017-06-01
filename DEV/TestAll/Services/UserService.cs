using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestAll.Dao;
using TestAll.Entitys;
using TestAll.Resposity;

namespace TestAll.Services
{
    public class UserService:IUserService
    {
        private readonly IRepository<Sys_User> _repository;

        public UserService(IRepository<Sys_User> repository)
        {
            _repository = repository;
        }

        public string TestService()
        {
            return ".TestService()";
        }

        public string Test2()
        {
            return _repository.Get(p=>p.Id==1).UserName;
        }
    }
}
