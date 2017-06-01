using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestAll.Config;

namespace TestAll.Dao
{
    /// <summary>
    /// 初始化数据库
    /// DropCreateDatabaseIfModelChanges
    /// </summary>
    public class InitDB
    {
        public async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            //var migrations = await context.Database.GetPendingMigrationsAsync();//获取未应用的Migrations，不必要，MigrateAsync方法会自动处理
            //根据migrations修改/创建数据库
            using (var ser = serviceProvider.CreateScope())
            {
                var db = ser.ServiceProvider.GetService<TestAllDbContext>();
                await db.Database.MigrateAsync();
            }
        }
    }
}
