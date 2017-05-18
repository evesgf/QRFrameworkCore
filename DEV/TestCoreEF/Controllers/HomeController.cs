using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;
using TestCoreEF.Dao;
using TestCoreEF.Models;
using TestCoreEF.Repository;
using TestCoreEF.Services;

namespace TestCoreEF.Controllers
{
    public class HomeController : Controller
    {
        //Service
        private readonly IUserService _userService;

        //仓储
        private readonly IRepository<SYS_Model> _repository;  

        //配置
        private readonly ApplicationConfiguration _options;

        public HomeController(
            IUserService uerService,
            IRepository<SYS_Model> repository,
            IOptions<ApplicationConfiguration> appConfiguration)
        {
            _userService = uerService;
            _repository = repository;
            _options = appConfiguration.Value;
        }

        public IActionResult Index()
        {
            var model = new SYS_Model
            {
                UserName = "123"
            };

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = _userService.Test();

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
