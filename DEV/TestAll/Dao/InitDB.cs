using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace TestAll.Dao
{
    /// <summary>
    /// 初始化数据库
    /// DropCreateDatabaseIfModelChanges
    /// </summary>
    public class InitDB
    {
        public void Init()
        {
            var db=new TestAllDbContext();
            db.Database.EnsureCreated();
        }
    }
}
