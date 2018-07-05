using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class AdjustmentItem
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Adjustment")]
        public int AdjId { get; set; }
        [ForeignKey("InventoryItem")]
        public int InvItemId { get; set; }
        public int QtyOH { get; set; }
        public int Variance { get; set; }
        public int NewQty { get; set; }
        [ForeignKey("MeasurementUnit")]
        public int Unit { get; set; }

        public virtual Adjustment Adjustment { get; set; }
        public virtual InventoryItem InventoryItem { get; set; }
        public virtual MeasurementUnit MeasurementUnit { get; set; }
    }
}
