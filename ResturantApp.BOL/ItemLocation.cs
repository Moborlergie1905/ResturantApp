using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class ItemLocation
    {
        public int ID { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int Quantity { get; set; }

        public virtual InventoryItem Item { get; set; }
        public virtual Location Location { get; set; }
    }
}
