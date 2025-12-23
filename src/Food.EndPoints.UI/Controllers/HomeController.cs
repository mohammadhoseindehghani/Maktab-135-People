using Food.EndPoints.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Food.Framework.Web;
using Microsoft.AspNetCore.Authorization;

namespace Food.EndPoints.UI.Controllers
{
    [AllowAnonymous]
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

		public IActionResult Profile()
		{
			if (User.Identity.IsAuthenticated == false)
				return Unauthorized();

			var userId = User.GetCurrentUserId();
            // Load Current User Profile()
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
