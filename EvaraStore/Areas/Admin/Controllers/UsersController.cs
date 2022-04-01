using EvaraStore.Bl;
using EvaraStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {

        // Dependance Injection
        private readonly UserManager<AppUser> userManager;
        private IPasswordHasher<AppUser> passwordHasher;
        IOrderService IOrderService;
        public UsersController(IOrderService _order, UserManager<AppUser> userManager, IPasswordHasher<AppUser> passwordHasher)
        {
            this.userManager = userManager;
            this.passwordHasher = passwordHasher;
            IOrderService = _order;
        }

        // View All Users
        public IActionResult List()
        {
            UserOrderModel model = new UserOrderModel();
            model.lstUsers = userManager.Users.ToList();
            model.lstOrder = IOrderService.GetAll();

            return View(model);
        }

        // View User By Id
        public async Task<IActionResult> Edit(string id)
        {
            AppUser model = await userManager.FindByIdAsync(id);

            return View(model);
        }

        // Form For Block User
        [HttpPost]
        public async Task<IActionResult> Block(AppUser user)
        {
            AppUser blockUser = await userManager.FindByIdAsync(user.Id);

            blockUser.LockoutEnd = user.LockoutEnd;

            var result = userManager.UpdateAsync(blockUser);
            if (result.Result.Succeeded)
            {
                TempData["Success"] = "Block User Successfully..";
                return RedirectToAction("List");
            }
            else
            {
                return View("Edit", user);
            }
        }

        // Delete User By Id
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            var result = userManager.DeleteAsync(user);

            TempData["Success"] = "Delete User Successfully..";
            return RedirectToAction("List");
        }

    }
}
