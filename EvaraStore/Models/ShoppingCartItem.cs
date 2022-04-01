using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Models
{
    public class ShoppingCartItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ImageName { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public int Stock { get; set; }
        public decimal Total { get; set; }
    }
}
