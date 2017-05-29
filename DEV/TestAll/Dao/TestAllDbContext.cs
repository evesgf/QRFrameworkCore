using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAll.Entitys;

namespace TestAll.Dao
{
    public class TestAllDbContext:DbContext
    {
        public DbSet<Sys_User> Sys_User { get; set; }
    }
}
