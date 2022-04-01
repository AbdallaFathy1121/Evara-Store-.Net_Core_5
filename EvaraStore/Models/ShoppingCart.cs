using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            lstItems = new List<ShoppingCartItem>();
        }

        public List<ShoppingCartItem> lstItems { get; set; }

        public decimal total { get; set; }
    }
}
