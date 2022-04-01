using System;
using System.Collections.Generic;

#nullable disable

namespace EvaraStore.Models
{
    public partial class TbCategory
    {
        public TbCategory()
        {
            TbItems = new HashSet<TbItem>();
            TbSubCategories = new HashSet<TbSubCategory>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImageName { get; set; }
        public DateTime? CreationDate { get; set; }


        public virtual ICollection<TbItem> TbItems { get; set; }
        public virtual ICollection<TbSubCategory> TbSubCategories { get; set; }

    }
}
