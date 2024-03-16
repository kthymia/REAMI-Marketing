using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using REAMI_Marketing_Sales___Inventory_System.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Filters;
using REAMI_Marketing_Sales___Inventory_System.Data;

namespace REAMI_Marketing_Sales___Inventory_System.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ILogger<BaseController> _logger;
        protected readonly AppDbContext _context;

        public BaseController(ILogger<BaseController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            // Check if admin is logged in
            var adminLoggedIn = HttpContext.Session.GetString("adminLoggedIn");
            if (string.IsNullOrEmpty(adminLoggedIn) || !bool.Parse(adminLoggedIn))
            {
                // If not logged in, redirect to login page
                context.Result = RedirectToAction("Login", "Home");
            }
        }
    }
}
