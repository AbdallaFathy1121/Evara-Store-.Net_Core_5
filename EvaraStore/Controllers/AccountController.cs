using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using EvaraStore.Models;
using Books.Bl;
using Microsoft.AspNetCore.Http;
using System.IO;
using EvaraStore.Bl;

namespace EvaraStore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // User Manager & Dependecy Injection
        private readonly UserManager<AppUser> userManager;
        private IPasswordHasher<AppUser> passwordHasher;
        IBillingService bill;
        IOrderService IOrderService;
        public AccountController(UserManager<AppUser> userManager, IPasswordHasher<AppUser> passwordHasher, IBillingService _bill, IOrderService _order)
        {
            this.userManager = userManager;
            this.passwordHasher = passwordHasher;
            bill = _bill;
            IOrderService = _order;
        }


        // View Account Page
        public async Task<IActionResult> Index()
        {
            AppUser appUser = await userManager.GetUserAsync(HttpContext.User);

            AccountPageModel model = new AccountPageModel();
            model.billing = bill.GetById(appUser.Id);
            model.lstOrder = IOrderService.GetByUserId(appUser.Id);

            // User Account
            model.userEdit = new UserEdit() {
                UserName = appUser.UserName,
                Email = appUser.Email,
                Password = appUser.PasswordHash
            };

            return View(model);
        }

        // Update User Form
        [HttpPost]
        public async Task<IActionResult> Index(AccountPageModel model)
        {

            if (ModelState.IsValid)
            {
                AppUser appUser = await userManager.GetUserAsync(HttpContext.User);

                appUser.Email = model.userEdit.Email;
                appUser.UserName = model.userEdit.UserName;
                if (model.userEdit.Password != null)
                {
                    appUser.PasswordHash = passwordHasher.HashPassword(appUser, model.userEdit.Password);
                }

                IdentityResult result = await userManager.UpdateAsync(appUser);
                if (result.Succeeded)
                {
                    TempData["UpdateUser"] = "Update your Account Successfully..";
                    return Redirect("~/Account");
                }
                else
                {
                    TempData["Errors"] = "UserName Or Email Was Token, Please try Again..";
                    return Redirect("~/Account");
                }
            }
            else
            {
                TempData["Errors"] = "Update Account was Faild, Please try Again..";
                return View("Index", new AccountPageModel());
            }

        }


        // Billing Form
        [HttpPost]
        public async Task<ActionResult> Billing(TbBilling billing)
        {
            AppUser appUser = await userManager.GetUserAsync(HttpContext.User);
            billing.UserId = appUser.Id;
            billing.UserName = appUser.UserName;
            billing.UserEmail = appUser.Email;

            if (ModelState.IsValid)
            {
                if (billing.Id == 0)
                    bill.Add(billing);
                else
                    bill.Edit(billing);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Index", billing);
            }
        }
    }
}
