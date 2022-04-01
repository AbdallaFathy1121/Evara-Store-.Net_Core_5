using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Models
{
    public class CheckoutModel
    {
        public ShoppingCart Cart { get; set; }
        public TbBilling Billing { get; set; }
    }
}
