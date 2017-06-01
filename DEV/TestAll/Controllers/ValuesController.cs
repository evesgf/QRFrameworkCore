using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        private readonly IUserService _userService;

        public ValuesController(IAppConfigService appConfigService,
            IUserService userService)
        {
            _appConfigService = appConfigService;

            _userService = userService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var a = _appConfigService.GetAppSettings<AppConfig>("DBConfig").DbLink;

            //var a = _appConfigService.appConfigurations;

            return new string[] { _userService.Test2(), _userService.TestService() };
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
