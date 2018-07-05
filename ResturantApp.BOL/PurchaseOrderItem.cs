using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class PurchaseOrderItem
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("PurchaseOrder")]
        public int PurchOrderId { get; set; }
        [ForeignKey("InventoryItem")]
        public int InventItemId { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("MeasurementUnit")]
        public int Unit { get; set; }
        public decimal price { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual InventoryItem InventoryItem { get; set; }
        public virtual Location Location { get; set; }
        public virtual MeasurementUnit MeasurementUnit { get; set; }
    }
}
