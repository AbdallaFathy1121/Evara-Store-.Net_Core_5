using cloudscribe.Pagination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Models
{
    public class ListItemModel
    {

        public IEnumerable<TbItem> lstItems { get; set; }
        public IEnumerable<TbCategory> lstCategories { get; set; }
        public IEnumerable<TbSubCategory> lstSubCategories { get; set; }
        public PageResult lstPageResult { get; set; }
    }
}
