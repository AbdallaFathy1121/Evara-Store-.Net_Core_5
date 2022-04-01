using EvaraStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace EvaraStore.Controllers
{
    public class UsersController : Controller
    {
        // User Manager & SignIn Manager
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        public UsersController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // View Register Page
        public IActionResult Register()
        {
            return View();
        }

        // View Login Page
        public IActionResult Login(string ReturnUrl)
        {
            Login model = new Login()
            {
                ReturnUrl = ReturnUrl
            };
            return View(model);
        }

        /// ///////////////////////////////////////////////

        // Method Register User
        [HttpPost]
        public async Task<IActionResult> FormRegister(User user)
        {
            AppUser appUser = new AppUser()
            {
                UserName = user.UserName,
                Email = user.Email,
                CreationDate = DateTime.Now
            };

            if (user.Password1 == user.Password2)
            {
                IdentityResult result = await userManager.CreateAsync(appUser, user.Password1);

                if (result.Succeeded)
                {
                    return Redirect("~/Users/Login");
                }
                else
                {
                    var errors = result.Errors.ToArray();
                    TempData["Errors"] = errors[0].Description;
                    return View("Register", new User());
                }
            }
            else
            {
                TempData["ValidatePassword"] = "Password Didn't Match";
                return View("Register", new User());
            }
        }

        // Method Login User
        [HttpPost]
        public async Task<IActionResult> FormLogin(Login login)
        {
            AppUser appUser = await userManager.FindByEmailAsync(login.Email);

            if(appUser != null)
            {
                SignInResult result = await signInManager.PasswordSignInAsync(appUser, login.Password, false, false);

                if (string.IsNullOrEmpty(login.ReturnUrl))
                    login.ReturnUrl = "~/";

                if (result.Succeeded)
                {
                    TempData["LogIn"] = "Login was Successfully..";
                    return Redirect(login.ReturnUrl);
                }
                else
                {
                    if (result.IsLockedOut)
                        TempData["Errors"] = "Your Account was Blocked to: " + appUser.LockoutEnd.Value.DateTime;
                    else
                        TempData["Errors"] = "UserName or Password was Rong, Please Try Again..";
                    return View("Login", new Login());
                }
            }
            return View(login);
        }

        // Method LogOut 
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            TempData["LogOut"] = "LogOut was Successfully..";
            return Redirect("~/");
         }

    }
}
