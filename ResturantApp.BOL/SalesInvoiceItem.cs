using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class SalesInvoiceItem
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("SalesInvoice")]
        public int SaleInvId { get; set; }
        [ForeignKey("InventoryItem")]
        public int InventItemId { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("MeasurementUnit")]
        public int Unit { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }

        public virtual SalesInvoice SalesInvoice { get; set; }
        public virtual InventoryItem InventoryItem { get; set; }
        public virtual MeasurementUnit MeasurementUnit { get; set; }
    }
}
