using System;
using System.Collections.Generic;

#nullable disable

namespace EvaraStore.Models
{
    public partial class TbSubCategory
    {
        public TbSubCategory()
        {
            TbItems = new HashSet<TbItem>();
        }

        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual TbCategory Category { get; set; }
        public virtual ICollection<TbItem> TbItems { get; set; }
    }
}
