using Food.EndPoints.UI.Models.Account;
using Food.Infra.Data.Db.SqlServer.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Food.EndPoints.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "خطا در ورود");
            return View(model);
        }


        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                NationalCode = model.NationalCode
            }; 
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                result.Errors.ToList().ForEach(error =>
                    ModelState.AddModelError(string.Empty, TranslateIdentityErrors(error.Code)));
                return View(model);
            }
            //ModelState.AddModelError(string.Empty, "مشکلی در فرآیند ثبت نام بوجود آمده است.");

        }

        private string TranslateIdentityErrors(string errorCode)
        {
            return errorCode switch
            {
                "DuplicateUserName" => "این نام کاربری قبلا ثبت شده است.",
                "DuplicateEmail" => "این ایمیل قبلا ثبت شده است.",
                "InvalidEmail" => "ایمیل وارد شده معتبر نیست.",
                "PasswordTooShort" => "رمز عبور باید حداقل 7 کاراکتر باشد.",
                "PasswordRequiresNonAlphanumeric" => "رمز عبور باید شامل حداقل یک کاراکتر غیر الفبایی باشد.",
                "PasswordRequiresDigit" => "رمز عبور باید شامل حداقل یک عدد باشد.",
                "PasswordRequiresLower" => "رمز عبور باید شامل حداقل یک حرف کوچک باشد.",
                "PasswordRequiresUpper" => "رمز عبور باید شامل حداقل یک حرف بزرگ باشد.",
                _ => "خطایی در فرآیند ثبت نام رخ داده است."
            };
        }


        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
	        return View();

        }

	}
}
