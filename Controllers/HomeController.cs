using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyOption _myOption;

        public HomeController(IOptions<MyOption> myOption)
        {
            _myOption = myOption.Value;
        }
        public IActionResult Index()
        {
            var option1 = _myOption.Option1;
            var option2 = _myOption.Option2;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

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
