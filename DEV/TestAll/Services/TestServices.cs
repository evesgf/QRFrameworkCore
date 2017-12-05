using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAll.Services
{
    public class TestServices:ITestServices
    {
        public string Test()
        {
            return "TestServices.Test()";
        }
    }
}
