using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Models.Models;
using MovieLibrary.Models.Static;
using MovieLibrary.Models.ViewModels;

namespace MovieLibraryWeb.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login() => View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            var passwordCheck = await _userManager.CheckPasswordAsync(user!, loginVM.Password);
            if (user is null || !passwordCheck)
            {
                TempData["Error"] = "Логин или пароль введен неверно";
                return View(loginVM);
            }
            await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
            return RedirectToAction(actionName: "Index", controllerName: "Movies");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }
            var u = await _userManager.FindByEmailAsync(registerVM.Email);
            if (u is not null)
            {
                TempData["Error"] = "Пользователь с введенным email адресом уже зарегистрирован";
                return View(registerVM);
            }
            var user = new AppUser()
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                UserName = registerVM.UserName,
                Email = registerVM.Email,
                EmailConfirmed = true,
                PhoneNumber = registerVM.PhoneNumber,
                PhoneNumberConfirmed = true,
                UserAddress = new UserAddress()
                {
                    Country = registerVM.Country,
                    City = registerVM.City,
                }
            };
            var result = await _userManager.CreateAsync(user, registerVM.Password);
            if (!result.Succeeded)
            {
                TempData["Error"] = string.Join("\n", result.Errors.Select(e => e.Description));
                return View(registerVM);
            }
            var roleAssignRes = await _userManager.AddToRoleAsync(user, UserRolesValues.User);
            if (!roleAssignRes.Succeeded)
            {
                TempData["Error"] = string.Join(" - ", roleAssignRes.Errors.Select(e => e.Description));
                return View(registerVM);
            }
            return View("RegisterCompleted");
        }

    }
}
