using System.Diagnostics;
using Food.EndPoints.UI.Models;
using Food.Infra.Data.Db.SqlServer.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Food.EndPoints.UI.Controllers;

[Authorize(Roles = "Admin,SuperAdmin")]
public class UsersController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<AppUser> _userManager;

    public UsersController(ILogger<HomeController> logger,
	    UserManager<AppUser> userManager)
    {
	    _logger = logger;
	    _userManager = userManager;
    }
    public async Task<IActionResult> Index()
    {
	    var users = await _userManager.Users.ToListAsync();//.Where(w=>w.Email.StartsWith("m"))
	    return View(users);
    }

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
