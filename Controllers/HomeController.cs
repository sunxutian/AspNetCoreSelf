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
            var option = _myOption.Option;
            var key = _myOption.Key;
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

        [Route("/Error/{statusCode}")]
        public IActionResult Error(string statusCode)
        {
            ViewData["StatusCode"] = statusCode;
            return View();
        }
    }
}
