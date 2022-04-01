using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Models
{
    public class AdminPanalModel
    {
        public List<TbOrder> lstAllOrder { get; set; }
        public List<TbOrder> lstCompletedOrder { get; set; }
        public List<TbOrder> lstPendingOrder { get; set; }
        public List<TbOrder> lstRejectedOrder { get; set; }
        public List<AppUser> lstAllUsers { get; set; }
        public List<TbItem> lstAllItems { get; set; }
    }
}
