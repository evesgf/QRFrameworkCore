using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Servicelmp
{
    public class UserManage : IService.IUserManage
    {
        public string Test()
        {
            return "我实现了接口方法Test";
        }
    }
}
