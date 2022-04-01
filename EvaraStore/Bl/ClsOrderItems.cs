using EvaraStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Bl
{
    public interface IOrderItemsService
    {
        bool Add(List<TbOrderItems> oItem);
    }

    public class ClsOrderItems : IOrderItemsService
    {
        EvaraStoreContext ctx;
        public ClsOrderItems(EvaraStoreContext context)
        {
            ctx = context;
        }

        //Method Add List OrderItem
        public bool Add(List<TbOrderItems> oItem)
        {
            try
            {
                foreach (var o in oItem)
                {
                    ctx.Add<TbOrderItems>(o);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
