using EvaraStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Bl
{
    
    public interface IOrderService
    {
        List<TbOrder> GetAll();
        bool Add(TbOrder order);
        TbOrder GetByDate(DateTime dateTime);
        TbOrder GetById(int id);
        List<TbOrder> GetByUserId(string id);
        bool Edit(TbOrder order);
        List<TbOrder> GetOrderByCompleted();
        List<TbOrder> GetOrderByProcessing();
        List<TbOrder> GetOrderByRejected();
    }

    public class ClsOrder : IOrderService
    {
        EvaraStoreContext ctx;
        public ClsOrder(EvaraStoreContext context)
        {
            ctx = context;
        }

        // Get All Orders
        public List<TbOrder> GetAll()
        {
            List<TbOrder> lstOrder = ctx.TbOrder.Include(a => a.Billing).Include(a => a.TbOrderItems).ToList();

            return lstOrder;
        }

        // Get List<Oreder> By UserId
        public List<TbOrder> GetByUserId(string id)
        {
            List<TbOrder> lstOrder = ctx.TbOrder.Include(a => a.Billing).Include(a => a.TbOrderItems).Where(a => a.Billing.UserId == id).ToList();
            
            return lstOrder;
        }

        // Get Order By Date
        public TbOrder GetByDate(DateTime dateTime)
        {
            TbOrder order = ctx.TbOrder.FirstOrDefault(a => a.Date == dateTime);
            return order;
        }

        // Get Order By ID
        public TbOrder GetById(int id)
        {
            TbOrder order = ctx.TbOrder.Include(a => a.TbOrderItems).Include(a => a.Billing).FirstOrDefault(a => a.OrderId == id);
            return order;
        }

        //Method Add New Order
        public bool Add(TbOrder order)
        {
            try
            {
                ctx.Add<TbOrder>(order);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Method Edit Order
        public bool Edit(TbOrder order)
        {
            try
            {
                ctx.Entry(order).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TbOrder> GetOrderByCompleted()
        {
            List<TbOrder> lstOrder = ctx.TbOrder.Include(a => a.Billing).Include(a => a.TbOrderItems).Where(a => a.Status == "Completed").ToList();
            return lstOrder;
        }

        public List<TbOrder> GetOrderByProcessing()
        {
            List<TbOrder> lstOrder = ctx.TbOrder.Include(a => a.Billing).Include(a => a.TbOrderItems).Where(a => a.Status == "Processing").ToList();
            return lstOrder;
        }
            
        public List<TbOrder> GetOrderByRejected()
        {
            List<TbOrder> lstOrder = ctx.TbOrder.Include(a => a.Billing).Include(a => a.TbOrderItems).Where(a => a.Status == "Rejected").ToList();
            return lstOrder;
        }
    }
}
