using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace QRFrameworkCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserManage _userManage;

        public HomeController(IUserManage userManage)
        {
            _userManage = userManage;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = _userManage.Test();

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
