using Microsoft.AspNetCore.Mvc;
using REAMI_Marketing_Sales___Inventory_System.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace REAMI_Marketing_Sales___Inventory_System.Controllers
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
            var adminLoggedIn = HttpContext.Session.GetString("adminLoggedIn");
            if (adminLoggedIn == "true")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet] // GET method to display login form
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost] // POST method to handle login form submission
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                // Set session storage indicating admin is logged in
                HttpContext.Session.SetString("adminLoggedIn", "true");
                return RedirectToAction("Index");
            }
            else
            {
                // Clear session storage if login fails
                HttpContext.Session.Remove("adminLoggedIn");
                // Return the login view with a model indicating invalid credentials
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                // Return the login view with the model containing the error
                return View();
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
