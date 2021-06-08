
using FruitVendor_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FruitVendor_MVC.Controllers
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
            return View();
        }

        // 1 public/View/build/
        public IActionResult UserSignUp()
        {
            return View();
        }
        // 2 public/View/build/
        public IActionResult UserSignIn()
        {
            return View();
        }
        // 3 secure/View/build/designed
        public IActionResult UserIndex()
        {
            return View();
        }
        // 4 secure/view/
        public IActionResult UserCart()
        {
            return View();
        }
        // 5 secure/view/
        public IActionResult UserOrder()
        {
            return View();
        }
        // 6 secure/view/
        public IActionResult UserFeedback()
        {
            return View();
        }

        //7 public=>secure
        public IActionResult UserCartDetails(int ? fruitId) 
        {
            // return Content("id=" + fruitId);
            ViewBag.getFruitId = fruitId;

            return View();
        }
        //  8 public=>secure
        public IActionResult UserCartEdit(int ?cartId)
        {
            ViewBag.getCartId = cartId;
            return View();
        }
        //  9
        public IActionResult UserProfile()
        {
            return View();
        }
        public IActionResult logout()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

