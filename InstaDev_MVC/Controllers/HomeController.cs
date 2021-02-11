using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InstaDev_MVC.Models;
using Microsoft.AspNetCore.Http;

namespace InstaDev_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // ViewBag que contem o nome logado na aplicação.
            ViewBag.UserName = HttpContext.Session.GetString("_UserName");
            return LocalRedirect("~/Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}