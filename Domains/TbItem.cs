using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace EvaraStore.Models
{
    public partial class TbItem
    {
        public TbItem()
        {
            TbImages = new HashSet<TbImages>();
            TbRate = new HashSet<TbRate>();
            TbOrderItems = new HashSet<TbOrderItems>();
        }

        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal OldPrice { get; set; }
        public int? Discount { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int? Qty { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ItemName { get; set; }


        public virtual TbCategory Category { get; set; }
        public virtual TbSubCategory SubCategory { get; set; }

        public virtual ICollection<TbImages> TbImages { get; set; }
        public virtual ICollection<TbRate> TbRate { get; set; }
        public virtual ICollection<TbOrderItems> TbOrderItems { get; set; }

        public static object AsNoTracking()
        {
            throw new NotImplementedException();
        }
    }
}
