using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TestAll.Config;
using TestAll.Dao;
using TestAll.Entitys;
using TestAll.Resposity;
using TestAll.Services;

namespace TestAll.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IAppConfigService _appConfigService;

        private IMemoryCache _memoryCache;

        private readonly IUserService _userService;

        public ValuesController(IAppConfigService appConfigService,
            IMemoryCache memoryCache,
            IUserService userService)
        {
            _appConfigService = appConfigService;
            _memoryCache = memoryCache;
            _userService = userService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var a = _appConfigService.GetAppSettings<AppConfig>("DBConfig").DbLink;

            //var a = _appConfigService.appConfigurations;

            string key1 = "value1";
            string key2 = "value2";

            string result1;
            string result2;

            if (!_memoryCache.TryGetValue(key1, out result1))
            {
                result1 = _userService.Test2();
                _memoryCache.Set(key1, result1);
            }

            if (!_memoryCache.TryGetValue(key2, out result2))
            {
                result2 = _userService.TestService();
                _memoryCache.Set(key2, result2);
            }

            return new string[] { result1, result2 };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
