using System.Globalization;
using Food.Infra.Data.Db.SqlServer.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Food.EndPoints.UI.Controllers
{
	[AllowAnonymous]
	public class SeedController : Controller
	{
		private readonly ILogger<SeedController> _logger;
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<IdentityRole<int>> _roleManager;

		public SeedController(
			ILogger<SeedController> logger,
			UserManager<AppUser> userManager,
			RoleManager<IdentityRole<int>> roleManager)
		{
			_logger = logger;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		/// <summary>
		/// Seed All Basedata
		/// </summary>
		/// <returns></returns>
		[HttpGet()]
		public async Task<IActionResult> Index()
		{
			try
			{
				await SeedRoles();
				await SeedUsers();

				return Ok();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw e;
			}
		}

		private async Task SeedRoles()
		{
			try
			{
				var roles = new List<(string Name, string Description)>
				{
					("Customer", "مشتریان"),
					("Admin", "مدیر"),
					("SuperAdmin", "مدیر کل"),
					("Manager", "مدیر مجموعه"),
				};
				foreach (var role in roles)
				{
					var isRoleExists = await _roleManager.RoleExistsAsync(role.Name);

					if (!isRoleExists)
					{
						var createdRole = await _roleManager.CreateAsync(new IdentityRole<int>(role.Name));
						_logger.LogWarning($"Role {role.Name} Created!");
					}
					else
					{
						_logger.LogError($"Role {role.Name} Existed!");
					}

				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		private async Task SeedUsers()
		{
			try
			{
				var users = new List<(string Email, string PhoneNumber, string Password, string[] Roles)>
				{
					("mahmoud@savarian.ir", "0935000000", "Mahmoud@1234567", new[] { "Admin", "SuperAdmin" })
				};
				foreach (var user in users)
				{
					var isUserExists = await _userManager.FindByEmailAsync(user.Email);

					if (isUserExists == null)
					{
						var newUser = new AppUser
						{
							Email = user.Email,
							UserName = user.Email,
							PhoneNumber = user.PhoneNumber
						};
						var createdUser = await _userManager.CreateAsync(newUser,user.Password);
						if (createdUser.Succeeded)
						{
							// Assign roles
							await _userManager.AddToRolesAsync(newUser, user.Roles);
							_logger.LogWarning($"User {user.Email} Created!");
						}

					}
					else
					{
						_logger.LogError($"User {user.Email} Existed!");
					}

				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

	}
}
