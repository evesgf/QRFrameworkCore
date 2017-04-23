using Service.IService.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Servicelmp.SysManage
{
    public class UserManage : IUserManage
    {
        public string Test()
        {
            return "实现了接口方法Test";
        }
    }
}
