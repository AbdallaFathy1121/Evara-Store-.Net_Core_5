using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EvaraStore.Models
{
    public partial class TbBilling
    {

        public TbBilling()
        {
            TbOrder = new HashSet<TbOrder>();
        }

        // Billing
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }

        // User
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }


        public virtual ICollection<TbOrder> TbOrder { get; set; }
    }
}
