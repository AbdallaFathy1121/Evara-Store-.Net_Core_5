using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Models
{
    public class UserOrderModel
    {
        public List<AppUser> lstUsers { get; set; }
        public List<TbOrder> lstOrder { get; set; }
    }
}
