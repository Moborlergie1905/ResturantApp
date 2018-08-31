using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class StockHistory
    {
        public int ID { get; set; }
        [ForeignKey("Item")]
        [DisplayName("Item")]
        public int ItemId { get; set; }
        [Display(Name = "Date stocked")]
        public DateTime DateStocked { get; set; }
        public int Quantity { get; set; }

        public virtual InventoryItem Item { get; set; }
    }
}
