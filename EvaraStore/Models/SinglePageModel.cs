using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Models
{
    public class SinglePageModel
    {

        public TbItem Item { get; set; }
        public TbRate Rate { get; set; }
        public IEnumerable<TbItem> LstRelatedItems { get; set; }

    }
}
