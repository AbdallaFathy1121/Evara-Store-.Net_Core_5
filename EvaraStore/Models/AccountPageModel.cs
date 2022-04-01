using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Models
{
    public class AccountPageModel
    {
        public UserEdit userEdit { get; set; }
        public TbBilling billing { get; set; }
        public List<TbOrder> lstOrder { get; set; }
    }
}
