using EvaraStore.Bl;
using EvaraStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class HomeController : Controller
    {
        // Dependency Injection & User Manager
        private readonly UserManager<AppUser> userManager;
        IOrderService IOrderService;
        IItemService IItemService;
        public HomeController(IOrderService _order, IItemService _item, UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
            IItemService = _item;
            IOrderService = _order;
        }
            
        public IActionResult Index()
        {
            AdminPanalModel model = new AdminPanalModel();
            model.lstAllItems = IItemService.GetAll();
            model.lstAllOrder = IOrderService.GetAll();
            model.lstAllUsers = userManager.Users.ToList();
            model.lstCompletedOrder = IOrderService.GetOrderByCompleted();
            model.lstPendingOrder = IOrderService.GetOrderByProcessing();
            model.lstRejectedOrder = IOrderService.GetOrderByRejected();

            TempData["TotalEarning"] = model.lstCompletedOrder.Sum(a => a.Total);

            return View(model);
        }


    }
}
