using EvaraStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Bl
{
    public interface ISubCategoryService
    {
        List<TbSubCategory> GetAll();
        public TbSubCategory GetById(int id);
        public bool Add(TbSubCategory subCat);
        public bool Edit(TbSubCategory subCategory);
        public bool Delete(int id);
    }

    public class ClsSubCategories : ISubCategoryService
    {
        EvaraStoreContext ctx;
        public ClsSubCategories(EvaraStoreContext context)
        {
            ctx = context;
        }

        public List<TbSubCategory> GetAll()
        {
            return ctx.TbSubCategories.Include(a=> a.Category).ToList();
        }

        //Method Get SubCategory By Id
        public TbSubCategory GetById(int id)
        {
            TbSubCategory cat = ctx.TbSubCategories.Include(a => a.Category).FirstOrDefault(a => a.SubCategoryId == id);
            return cat;
        }

        //Method Add New SubCategory
        public bool Add(TbSubCategory subCat)
        {
            try
            {
                ctx.Add<TbSubCategory>(subCat);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Method Edit SubCategory
        public bool Edit(TbSubCategory subCategory)
        {
            try
            {
                ctx.Entry(subCategory).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Method Delete SubCategory By Id
        public bool Delete(int id)
        {
            try
            {
                TbSubCategory oldCat = ctx.TbSubCategories.Where(a => a.SubCategoryId == id).FirstOrDefault();
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
