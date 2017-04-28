using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;
using TestCoreEF.Dao;
using TestCoreEF.Models;

namespace TestCoreEF.Controllers
{
    public class HomeController : Controller
    {
        private readonly TestDBContext _testDBContext;
        private readonly ApplicationConfiguration _options;

        public HomeController(TestDBContext testDBContext, IOptions<ApplicationConfiguration> appConfiguration)
        {
            _testDBContext = testDBContext;
            _options = appConfiguration.Value;
        }

        public IActionResult Index()
        {
            var model = new SYS_Model
            {
                UserName = "123"
            };
            _testDBContext.Add(model);
            _testDBContext.SaveChanges();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = _testDBContext.Sys_Model.ToList();

            return View();
        }

        public IActionResult Contact()
        {
            //读取配置


            ViewData["Message"] = "FileUpPath:"+ _options.FileUpPath;

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
