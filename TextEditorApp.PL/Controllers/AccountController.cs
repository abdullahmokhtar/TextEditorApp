using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TextEditorApp.PL.Models;

namespace TextEditorApp.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ILogger<AccountController> logger;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(
            UserManager<IdentityUser> userManager
            , ILogger<AccountController> logger
            , SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.logger = logger;
            this.signInManager = signInManager;
        }
        public IActionResult Login() => View();
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel data)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(data.Email);

                if (user is null)
                    ModelState.AddModelError("", "Email Not Found");

                if (user is not null && await userManager.CheckPasswordAsync(user, data.Password))
                {
                    var result = await signInManager.PasswordSignInAsync(user, data.Password, data.RememberMe, false);

                    if (result.Succeeded)
                        return RedirectToAction("Index", "Document");
                }
            }
            return View(data);
        }






        public IActionResult Register() => View();
        [HttpPost]
        public async Task<IActionResult> Register(SignUpViewModel data)
        {
            if (ModelState.IsValid && data.IsAgree)
            {
                var user = new IdentityUser { UserName = data.UserName, Email = data.Email };

                var result = await userManager.CreateAsync(user, data.Password);

                if (result.Succeeded)
                    return RedirectToAction(nameof(Login));

                foreach (var error in result.Errors)
                {
                    logger.LogError(error.Description);
                    ModelState.AddModelError("", error.Description);
                }
            }
            foreach (var modelState in ViewData.ModelState.Values.ToList())
            {
                foreach (ModelError error in modelState.Errors.ToList())
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
            }
            return View(data);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        public IActionResult AccessDenied => View();
    }
}
