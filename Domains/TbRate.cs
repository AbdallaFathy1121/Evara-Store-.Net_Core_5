using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EvaraStore.Models
{
    public partial class TbRate
    {
        // Rate
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Star { get; set; }

        [RegularExpression(@"^.{8,100}$", ErrorMessage = "Name should be of minimum 8 and maximum 100 characters")]
        public string Comment { get; set; }
        public DateTime CreationDate { get; set; }

        // User
        public string UserId { get; set; }
        public string UserName { get; set; }


        public virtual TbItem Item { get; set; }

    }
}
