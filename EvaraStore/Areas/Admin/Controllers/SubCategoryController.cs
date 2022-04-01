using Books.Bl;
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

    public class SubCategoryController : Controller
    {
        // Dependence Injection
        ISubCategoryService cat;
        ICategoryService CategoryService;
        public SubCategoryController(ISubCategoryService _cat, ICategoryService category)
        {
            cat = _cat;
            CategoryService = category;
        }

        // View All SubCategories
        public IActionResult List()
        {
            List<TbSubCategory> Subcategory = cat.GetAll();
            return View(Subcategory);
        }

        // Edit Category By Id Or Add New Category
        public IActionResult Edit(int? id)
        {
            ViewBag.Categories = CategoryService.GetAll();
            if (id != null)
            {
                return View(cat.GetById(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }
        }

        // Delete Category 
        public IActionResult Delete(int Subcategory)
        {
            cat.Delete(Subcategory);
            return RedirectToAction("List");
        }

        // Form
        [HttpPost]
        public ActionResult Save(TbSubCategory subCategory)
        {

            if (ModelState.IsValid)
            {
                subCategory.CreationDate = DateTime.Now;

                if (subCategory.SubCategoryId == 0)
                    cat.Add(subCategory);
                else
                    cat.Edit(subCategory);

                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Categories = CategoryService.GetAll();
                return View("Edit", subCategory);
            }
        }
    }
}
