using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using EvaraStore.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Bl
{
    public interface IBillingService
    {
        TbBilling GetById(string id);
        bool Add(TbBilling cat);
        bool Edit(TbBilling category);
    }

    public class ClsBilling : IBillingService
    {
        EvaraStoreContext ctx;
        public ClsBilling(EvaraStoreContext context)
        {
            ctx = context;
        }


        //Method Get Billing By UserId
        public TbBilling GetById(string id)
        {
            TbBilling cat = ctx.TbBilling.FirstOrDefault(a => a.UserId == id);
            return cat;
        }

        //Method Add New Billing
        public bool Add(TbBilling bill)
        {
            try
            {
                ctx.Add<TbBilling>(bill);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Method Edit Billing
        public bool Edit(TbBilling bill)
        {
            try
            {
                ctx.Entry(bill).State = EntityState.Modified;
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
