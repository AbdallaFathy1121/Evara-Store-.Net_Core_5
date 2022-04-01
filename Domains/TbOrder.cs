using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EvaraStore.Models
{
    public partial class TbOrder
    {
        public TbOrder()
        {
            TbOrderItems = new HashSet<TbOrderItems>();
        }

        [Key]
        public int OrderId { get; set; }
        public int BillingId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
        public string SerialNumber { get; set; }

        // Relations
        public virtual TbBilling Billing { get; set; }
        public virtual ICollection<TbOrderItems> TbOrderItems { get; set; }
    }
}
