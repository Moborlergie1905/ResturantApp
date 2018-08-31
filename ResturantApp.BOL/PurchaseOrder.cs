using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class PurchaseOrder
    {
        [Key]
        public int PurchOrderId { get; set; }
        [ForeignKey("Supplier"), Display(Name = "Suplier")]
        public int SupplierId { get; set; }        
        public decimal Discount { get; set; }
        [Display(Name = "Order date")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Delivery date")]
        public DateTime DeliveryDate { get; set; }
        public string Note { get; set; }
        [Display(Name = "Total freight")]
        public decimal TotalFreight { get; set; }
        [Display(Name = "Other cost")]
        public decimal OtherCost { get; set; }
        [Display(Name = "Total custom")]
        public decimal TotalCustom { get; set; }
        public decimal Tax { get; set; }
        [Display(Name = "Tracker")]
        public string OrderTracker { get; set; }
        [Display(Name = "Delivery status")]
        public int DeliveryStatus { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
