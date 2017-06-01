using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAll.Dao;
using TestAll.Entitys;

namespace TestAll.Resposity
{
    public class TestRepository: Repository<Sys_User>
    {
        public TestRepository(TestAllDbContext context) : base(context)
        {
        }
    }
}
