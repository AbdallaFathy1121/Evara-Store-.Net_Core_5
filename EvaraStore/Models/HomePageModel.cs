using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Models
{
    public class HomePageModel
    {

        public IEnumerable<TbItem> LstNewItems { get; set; }
        public IEnumerable<TbItem> LstUpSell { get; set; }
        public IEnumerable<TbCategory> LstCategories { get; set; }

    }
}
