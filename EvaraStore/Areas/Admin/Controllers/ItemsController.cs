using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.Bl;
using Microsoft.AspNetCore.Http;
using System.IO;
using EvaraStore.Bl;
using EvaraStore.Models;
using Microsoft.AspNetCore.Authorization;

namespace Books.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class ItemsController : Controller
    {

        // Dependance Injection
        IItemService ItemService;
        ICategoryService CategoryService;
        ISubCategoryService SubCategoryService;
        public ItemsController(IItemService item, ICategoryService category, ISubCategoryService subCategory)
        {
            ItemService = item;
            CategoryService = category;
            SubCategoryService = subCategory;
        }

        // View All Items and Images
        public IActionResult List()
        {
            ListItemModel model = new ListItemModel();
            model.lstItems = ItemService.GetAll();

            return View(model);
        }

        // Edit Item By Id Or Add New Item
        public IActionResult Edit(int? id)
        {
            ViewBag.Categories = CategoryService.GetAll();
            ViewBag.SubCategories = SubCategoryService.GetAll();

            if (id != null)
            {
                return View(ItemService.GetById(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }
        }

        // Delete Item with Images
        public IActionResult Delete (int item)
        {
            ItemService.Delete(item);
            ItemService.DeleteImages(item);
            return RedirectToAction("List");
        }

        // Action Form
        [HttpPost]
        public async Task<ActionResult> Save(TbItem item, List<TbImages> itemImage, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                item.CreationDate = DateTime.Now;

                if (item.ItemId == 0)
                {
                    ItemService.Add(item);
                }
                else
                {
                    ItemService.Edit(item);
                    ItemService.DeleteImages(item.ItemId);
                }


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

                        itemImage.Add(new TbImages()
                        {
                            ImageName = ImageName,
                            ItemId = item.ItemId
                        });
                    }
                }

                ItemService.AddImages(itemImage);


                return RedirectToAction("List");
            } 
            else
            {
                ViewBag.Categories = CategoryService.GetAll();
                ViewBag.SubCategories = SubCategoryService.GetAll();
                return View("Edit", item);
            }
        }
    
    }
}
