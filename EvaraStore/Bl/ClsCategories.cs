using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using EvaraStore.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Bl
{

    public interface ICategoryService
    {
        List<TbCategory> GetAll();
        TbCategory GetById(int id);
        bool Add(TbCategory cat);
        bool Edit(TbCategory category);
        bool Delete(int id);
    }

    public class ClsCategories : ICategoryService
    {
        EvaraStoreContext ctx;
        public ClsCategories(EvaraStoreContext context)
        {
            ctx = context;
        }

        // View All Categories
        public List<TbCategory> GetAll()
        {
            return ctx.TbCategories.ToList();
        }

        //Method Get Category By Id
        public TbCategory GetById(int id)
        {
            TbCategory cat = ctx.TbCategories.FirstOrDefault(a => a.CategoryId == id);
            return cat;
        }

        //Method Add New Category
        public bool Add(TbCategory cat)
        {
            try
            {
                ctx.Add<TbCategory>(cat);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Method Edit Category
        public bool Edit(TbCategory category)
        {
            try
            {
                ctx.Entry(category).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Method Delete Category By Id
        public bool Delete(int id)
        {
            try
            {
                TbCategory oldCat = ctx.TbCategories.Where(a => a.CategoryId == id).FirstOrDefault();
                ctx.Remove(oldCat);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
