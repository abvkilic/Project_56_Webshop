using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopMeisterBE_MASTER.Models;

namespace ShopMeisterBE_MASTER.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Armbanden()
        {
            return View();
        }

        public IActionResult Kettingen()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Over_Ons()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
