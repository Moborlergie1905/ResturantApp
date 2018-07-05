using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class ProductionIngredient
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Production")]
        public int ProdId { get; set; }
        [ForeignKey("InventoryItem")]
        public int InvItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UntitCost { get; set; }
        public decimal TotalCost { get; set; }  
        [ForeignKey("MeasurementUnit")]           
        public int Unit { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }

        public virtual Production  Production { get; set; }
        public virtual InventoryItem InventoryItem { get; set; }
        public virtual Location Location { get; set; }
        public virtual MeasurementUnit MeasurementUnit { get; set; }
    }
}
