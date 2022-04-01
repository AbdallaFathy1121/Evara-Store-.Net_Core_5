using EvaraStore.Bl;
using EvaraStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SettingController : Controller
    {
        // Dependance Injection
        ISettingService ISettingService;
        public SettingController(ISettingService _set)
        {
            ISettingService = _set;
        }

        // View Setting Page
        public IActionResult Index()
        {
            TbSetting model = new TbSetting();
            model = ISettingService.GetById(1);

            return View(model);
        }

        // Form Edit Settings
        [HttpPost]
        public IActionResult Save(TbSetting setting)
        {
            ISettingService.Edit(setting);
            TempData["Success"] = "Update Settings Successfully..";

            return RedirectToAction("Index");
        }
    }
}
