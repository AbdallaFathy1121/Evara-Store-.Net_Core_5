using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Models
{
    public partial class TbImages
    {

        [Key]
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public int ItemId { get; set; }


        public virtual TbItem Item { get; set; }


    }
}
