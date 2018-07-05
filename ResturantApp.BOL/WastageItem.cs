using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class WastageItem
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Wastage")]
        public int WastageId { get; set; }
        [ForeignKey("InventoryItem")]
        public int InvItemId { get; set; }
        public int Qty { get; set; }
        [ForeignKey("MeasurementUnit")]
        public int Unit { get; set; }
        public decimal UnitCost { get; set; }
        public decimal TotalCost { get; set; }
        public int OldQtyOH { get; set; }
        public int NewQtyOH { get; set; }

        public virtual Wastage Wastage { get; set; }
        public virtual InventoryItem InventoryItem { get; set; }
        public virtual MeasurementUnit MeasurementUnit { get; set; }
    }
}
