﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAll.Services
{
    public interface ITestServices:IDependencyRegister
    {
        string Test();
    }
}
