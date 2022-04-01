using EvaraStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Bl
{

    //Using Dipendece Ingection
    public interface IItemService
    {
        List<TbItem> GetAll();
        public List<TbImages> GetAllImages();
        TbItem GetById(int id);
        bool Add(TbItem item);
        bool Edit(TbItem item);
        bool Delete(int id);
        bool AddImages(List<TbImages> item);
        bool DeleteImages(int id);
        List<TbItem> GetMonthlyUpSell();
        List<TbItem> GetRelatedItems(decimal price, int CatId, int id);
        List<TbImages> GetImagesById(int id);
        public List<TbItem> GetItemsByCatName(string category);
        public List<TbItem> GetItemsBySubCatName(string category, string subCategory);
        public List<TbItem> GetAllItems(string sort, int pageNumber, int pageSize, int ExcludeRecords);
        public List<TbItem> GetItemsByCategory(string category, string sort, int pageNumber, int pageSize, int ExcludeRecords);
        public List<TbItem> GetItemsBySubCategory(string category, string subCategory, string sort, int pageNumber, int pageSize, int ExcludeRecords);
        List<TbItem> SearchItems(string search);

    }

    public class ClsItems : IItemService
    {
        //Context
       EvaraStoreContext ctx;
        public ClsItems(EvaraStoreContext context)
        {
            ctx = context;
        }

        //Method Get All Items
        public List<TbItem> GetAll()
        {
            List<TbItem> lstItems = ctx.TbItems.Include(a=> a.TbImages).Include(a => a.Category).Include(a => a.SubCategory)
                .OrderByDescending(a => a.CreationDate).ToList();

            return lstItems;
        }

        //Method Get Monthly UpSell Items 
        public List<TbItem> GetMonthlyUpSell()
        {
            List<TbItem> lstItems = ctx.TbItems.Include(a => a.TbImages).Include(a => a.Category).Include(a => a.SubCategory)
                .Where(a => a.CreationDate >= DateTime.Now.AddDays(-30) && a.Discount != null)
                .OrderByDescending(a => a.CreationDate).ToList();

            return lstItems;
        }

        //Method Get All Images
        public List<TbImages> GetAllImages()
        {
            List<TbImages> lstImages = ctx.TbImages.ToList();

            return lstImages;
        }

        //Method Get Item By Id
        public TbItem GetById(int id)
        {
            TbItem item = ctx.TbItems.Include(a => a.TbImages).Include(a=> a.Category).Include(a=> a.SubCategory).Include(a => a.TbRate).FirstOrDefault(a => a.ItemId == id);
            return item;
        }

        //Method Get Images By Id
        public List<TbImages> GetImagesById(int id)
        {
            List<TbImages> lstImages = ctx.TbImages.Where(a => a.ItemId == id).ToList();
            return lstImages;
        }

        //Method Add New Item
        public bool Add(TbItem item)
        {
            try
            {
                ctx.Add<TbItem>(item);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Method Add New List<Images> for One Item
        public bool AddImages(List<TbImages> item)
        {
            try
            {
                foreach(var image in item)
                {
                    ctx.Add<TbImages>(image);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Method Edit Item
        public bool Edit(TbItem item)
        {
            try
            {
                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Method Delete Item By Id
        public bool Delete(int id)
        {
            try
            {
                TbItem OldItem = ctx.TbItems.Where(a => a.ItemId == id).FirstOrDefault();
                ctx.Remove(OldItem);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Method Delete Images By ItemId
        public bool DeleteImages(int id)
        {
            try
            {
                List<TbImages> OldImages = ctx.TbImages.Where(a => a.ItemId == id).ToList();
                foreach(var image in OldImages)
                {
                    ctx.Remove(image);
                }
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Method Get Related Items By Price
        public List<TbItem> GetRelatedItems(decimal price, int CatId, int id)
        {
            decimal start = price - 1000;
            decimal end = price + 1000;

            List<TbItem> lstItems = ctx.TbItems
                .Include(a => a.TbImages)
                .Include(a => a.Category).Include(a => a.SubCategory)
                .Where(a => a.OldPrice >= start && a.OldPrice <= end && a.ItemId != id)
                .OrderByDescending(a => a.CreationDate).Take(20).ToList();

            return lstItems;
        }
        
        // Method Get Items By Category_Name
        public List<TbItem> GetItemsByCatName(string category)
        {
            List<TbItem> lstItems = ctx.TbItems
                .Include(a => a.TbImages)
                .Include(a => a.Category).Include(a => a.SubCategory)
                .Where(a=> a.Category.CategoryName == category)
                .OrderByDescending(a => a.CreationDate).ToList();

            return lstItems;
        }

        // Method Get Items By Category_Name & SubCategory_Name
        public List<TbItem> GetItemsBySubCatName(string category, string subCategory)
        {
            List<TbItem> lstItems = ctx.TbItems
                .Include(a => a.TbImages)
                .Include(a => a.Category).Include(a => a.SubCategory)
                .Where(a => a.Category.CategoryName == category && a.SubCategory.SubCategoryName == subCategory)
                .OrderByDescending(a => a.CreationDate).ToList();

            return lstItems;
        }

        // Method Get AllItems and Filter by Pagination
        public List<TbItem> GetAllItems(string sort, int pageNumber, int pageSize, int ExcludeRecords)
        {
                var sorted = from s in ctx.TbItems select s;

                switch (sort)
                {
                    case "price_asc":
                        sorted = sorted.OrderBy(a => a.OldPrice);
                        break;
                    case "price_dsc":
                        sorted = sorted.OrderByDescending(a => a.OldPrice);
                        break;
                    case "date_asc":
                        sorted = sorted.OrderBy(a => a.CreationDate);
                        break;
                    case "date_dsc":
                        sorted = sorted.OrderByDescending(a => a.CreationDate);
                        break;
                    default:
                        sorted = sorted.OrderByDescending(a=> a.CreationDate);
                        break;
                }

                List<TbItem> lstItems = sorted.Include(a => a.TbImages).Include(a => a.Category).Include(a => a.SubCategory)
                   .Skip(ExcludeRecords)
                   .Take(pageSize)
                   .ToList();

            return lstItems;
        }

        // Method Get Items By Category and Filter by Pagination
        public List<TbItem> GetItemsByCategory(string category, string sort, int pageNumber, int pageSize, int ExcludeRecords)
        {
            var sorted = from s in ctx.TbItems select s;

            switch (sort)
            {
                case "price_asc":
                    sorted = sorted.OrderBy(a => a.OldPrice);
                    break;
                case "price_dsc":
                    sorted = sorted.OrderByDescending(a => a.OldPrice);
                    break;
                case "date_asc":
                    sorted = sorted.OrderBy(a => a.CreationDate);
                    break;
                case "date_dsc":
                    sorted = sorted.OrderByDescending(a => a.CreationDate);
                    break;
                default:
                    sorted = sorted.OrderByDescending(a => a.CreationDate);
                    break;
            }

            List<TbItem> lstItems = sorted.Include(a => a.TbImages).Include(a => a.Category).Include(a => a.SubCategory)
                 .Where(a => a.Category.CategoryName == category)
                 .Skip(ExcludeRecords)
                 .Take(pageSize)
                 .ToList();

            return lstItems;
        }

        // Method Get Items By Category and SubCategory and Filter by Pagination
        public List<TbItem> GetItemsBySubCategory(string category, string subCategory, string sort, int pageNumber, int pageSize, int ExcludeRecords)
        {
            var sorted = from s in ctx.TbItems select s;

            switch (sort)
            {
                case "price_asc":
                    sorted = sorted.OrderBy(a => a.OldPrice);
                    break;
                case "price_dsc":
                    sorted = sorted.OrderByDescending(a => a.OldPrice);
                    break;
                case "date_asc":
                    sorted = sorted.OrderBy(a => a.CreationDate);
                    break;
                case "date_dsc":
                    sorted = sorted.OrderByDescending(a => a.CreationDate);
                    break;
                default:
                    sorted = sorted.OrderByDescending(a => a.CreationDate);
                    break;
            }

            List<TbItem> lstItems = sorted.Include(a => a.TbImages).Include(a => a.Category).Include(a => a.SubCategory)
                 .Where(a => a.Category.CategoryName == category && a.SubCategory.SubCategoryName == subCategory)
                 .Skip(ExcludeRecords)
                 .Take(pageSize)
                 .ToList();

            return lstItems;
        }

        //Method Get All Items
        public List<TbItem> SearchItems(string search)
        {
            var Items = from m in ctx.TbItems
                         select m;

            if (!String.IsNullOrEmpty(search))
            {
                Items = Items.Where(s => s.ItemName!.Contains(search));
            }

            List<TbItem> lstItems = Items.Include(a => a.TbImages).Include(a => a.Category).Include(a => a.SubCategory).ToList();

            return lstItems;
        }


    }
}
