using EvaraStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Bl
{
    //Using Dipendece Ingection
    public interface IRateService
    {
        bool Add(TbRate r);
        int GetById(int id);
    }
        
    public class ClsRate : IRateService
    {
        //Context
        EvaraStoreContext ctx;
        public ClsRate(EvaraStoreContext context)
        {
            ctx = context;
        }

        //Method Get Rate By ItemId
        public int GetById(int id)
        {
            List<TbRate> rate = ctx.TbRate.Where(a=> a.ItemId == id).ToList();
            int totalRate = 0;
            foreach(var r in rate)
            {
                totalRate += r.Star;
            }

            return totalRate;
        }

        //Method Add New Rate
        public bool Add(TbRate r)
        {
            try
            {
                ctx.Add<TbRate>(r);
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
