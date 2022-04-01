using Books.Models;
using EvaraStore.Bl;
using EvaraStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EvaraStore.Infrastructure
{
    public class SettingViewComponent : ViewComponent
    {
        // Dependence Injection
        ISettingService ISettingService;
        public SettingViewComponent(ISettingService _set)
        {
            ISettingService = _set;
        }

        // Method Get Setting By Id
        public IViewComponentResult Invoke()
        {
            TbSetting model = ISettingService.GetById(1);

            return View(model);
        }

    }
}
