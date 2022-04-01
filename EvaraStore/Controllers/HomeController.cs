using Books.Bl;
using EvaraStore.Bl;
using EvaraStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Controllers
{
    public class HomeController : Controller
    {
        
        // Dependence Injection
        IItemService ItemService;
        ICategoryService CategoryService;
        ISettingService ISettingService;
        public HomeController(IItemService _item, ICategoryService _cat, ISettingService _set)
        {
            ItemService = _item;
            CategoryService = _cat;
            ISettingService = _set;
        }

        // View HomePage
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.LstNewItems = ItemService.GetAll().Take(8);
            model.LstCategories = CategoryService.GetAll();
            model.LstUpSell = ItemService.GetMonthlyUpSell().Take(20);

            return View(model);
        }

    }
}
