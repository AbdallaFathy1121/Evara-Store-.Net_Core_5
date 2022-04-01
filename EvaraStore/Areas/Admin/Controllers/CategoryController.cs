using Books.Bl;
using EvaraStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {

        // Dependence Injection
        ICategoryService cat;
        public CategoryController(ICategoryService _cat)
        {
            cat = _cat;
        }


        // View All Categories
        public IActionResult List()
        {
            List<TbCategory> category =  cat.GetAll();
            return View(category);
        }

        // Edit Category By Id Or Add New Category
        public IActionResult Edit(int? id)
        {
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
        public IActionResult Delete(int category)
        {
            cat.Delete(category);
            return RedirectToAction("List");
        }

        // Action Form
        [HttpPost]
        public async Task<ActionResult> Save(TbCategory category, List<IFormFile> Files)
        {

            if (ModelState.IsValid)
            {
                category.CreationDate = DateTime.Now;

                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        category.ImageName = ImageName;
                    }
                }

                if (category.CategoryId == 0)
                    cat.Add(category);
                else
                    cat.Edit(category);


                return RedirectToAction("List");
            }
            else
            {
                return View("Edit", category);
            }
        }

    }
}
