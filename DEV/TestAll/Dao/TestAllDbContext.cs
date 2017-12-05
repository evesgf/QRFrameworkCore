using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAll.Entitys;
using TestAll.Mappings;

namespace TestAll.Dao
{
    /// <summary>
    /// 生成数据库架构：Add-Migration MyFirstMigration
    /// 开启自动迁移：Enable-Migrations -EnableAutomaticMigrations
    /// 更新数据库：Update-Database
    /// </summary>
    public class TestAllDbContext:DbContext
    {
        public TestAllDbContext()
        {
        }

        public TestAllDbContext(DbContextOptions<TestAllDbContext> options) : base(options){}

        //public DbSet<Sys_User> Sys_User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //关联Mapping
            new UserMapping(modelBuilder.Entity<Sys_User>());
        }
    }
}
