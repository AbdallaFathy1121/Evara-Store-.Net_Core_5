using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Models
{
    public class SearchModel
    {
        public List<TbItem> lstItems { get; set; }
        public List<TbCategory> lstCategories { get; set; }
        public List<TbSubCategory> lstSubCategories { get; set; }
    }
}
