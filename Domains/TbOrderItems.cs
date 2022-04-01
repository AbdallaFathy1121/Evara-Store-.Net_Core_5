using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EvaraStore.Models
{
    public partial class TbOrderItems
    {
        [Key]
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public string ImageName { get; set; }
        public string ItemName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }


        // Relations
        public virtual TbOrder Order { get; set; }
        public virtual TbItem Item { get; set; }

    }
}
