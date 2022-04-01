using Books.Bl;
using EvaraStore.Bl;
using EvaraStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cloudscribe.Pagination.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EvaraStore.Controllers
{
    public class ShopController : Controller
    {
        IItemService ItemService;
        ICategoryService CategoryService;
        ISubCategoryService subCategoryService;
        public ShopController(IItemService _Item, ICategoryService _cat, ISubCategoryService _sub)
        { 
            ItemService = _Item;
            CategoryService = _cat;
            subCategoryService = _sub;
        }

        // View All Items
        public IActionResult Index(string sort, int pageNumber = 1, int pageSize = 9)
        {
            ViewData["itemsCount"] = ItemService.GetAll().ToList().Count();
            
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            ListItemModel model = new ListItemModel();
            model.lstItems = ItemService.GetAllItems(sort, pageNumber, pageSize, ExcludeRecords);
            model.lstCategories = CategoryService.GetAll();
            model.lstSubCategories = subCategoryService.GetAll();

            model.lstPageResult = new PageResult()
            {
                pageNumber = pageNumber,
                pageSize = pageSize
            };

            return View(model);
        }

        // View Items By Category
        public IActionResult Category(string id, string sort, int pageNumber = 1, int pageSize = 9)
        {
            ViewData["itemsCount"] = ItemService.GetItemsByCatName(id).ToList().Count();
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            ListItemModel model = new ListItemModel();
            model.lstItems = ItemService.GetItemsByCategory(id, sort, pageNumber, pageSize, ExcludeRecords);
            model.lstCategories = CategoryService.GetAll();
            model.lstSubCategories = subCategoryService.GetAll();

            model.lstPageResult = new PageResult()
            {
                pageNumber = pageNumber,
                pageSize = pageSize
            };

            return View(model);
        }

        // View Items By Category and SubCategory
        public IActionResult SubCategory(string id, string sort, int pageNumber = 1, int pageSize = 9)
        {
            var arr = id.Split("--");
            string category = arr[0];
            string subCategory = arr[1];

            ViewData["itemsCount"] = ItemService.GetItemsBySubCatName(category, subCategory).ToList().Count();
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            ListItemModel model = new ListItemModel();
            model.lstItems = ItemService.GetItemsBySubCategory(category, subCategory, sort, pageNumber, pageSize, ExcludeRecords);
            model.lstCategories = CategoryService.GetAll();
            model.lstSubCategories = subCategoryService.GetAll();

            model.lstPageResult = new PageResult()
            {
                pageNumber = pageNumber,
                pageSize = pageSize
            };

            return View(model);
        }

        // Form To Search For Products
        [HttpPost]
        public IActionResult Search()
        {
            var searchTerm = Request.Form["search"];
            ViewData["SearchTerm"] = searchTerm;

            SearchModel model = new SearchModel();
            model.lstItems = ItemService.SearchItems(searchTerm);
            model.lstCategories = CategoryService.GetAll();
            model.lstSubCategories = subCategoryService.GetAll();

            ViewData["itemsCount"] = model.lstItems.Count();

            return View(model);
        }

    }
}
