using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class DeliveryItem
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Delivery")]
        public int DeliveryId { get; set; }
        [ForeignKey("InventoryItem")]
        public int InvItemId { get; set; }
        public int AvailQty { get; set; }
        public int Qty { get; set; }
        public string Unit { get; set; }
        public decimal UnitCost { get; set; }
        public decimal TotalCost { get; set; }

        public virtual InventoryItem InventoryItem { get; set; }
        public virtual Delivery Delivery { get; set; }
    }
}
