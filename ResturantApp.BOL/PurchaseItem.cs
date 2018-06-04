using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class PurchaseItem
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Purchase")]
        public int PurchaseId { get; set; }
        [ForeignKey("InverntoryItem")]
        public int InventItemId { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public decimal price { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }        
        //[ForeignKey("Location")]
        //public int LocationId { get; set; }

        public virtual Purchase Purchase { get; set; }
        public virtual InventoryItem InverntoryItem { get; set; }
        //public virtual Location Location { get; set; }
    }
}
