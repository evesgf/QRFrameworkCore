using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCoreEF.Models;

namespace TestCoreEF.Dao
{
    public class TestDBContext:DbContext
    {
        public TestDBContext(DbContextOptions<TestDBContext> options)
            :base(options)
        {
            
        }

        public DbSet<SYS_Model> Sys_Model { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
