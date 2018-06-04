using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class Expiration
    {
        public int ID { get; set; }
        [ForeignKey("InventoryItem")]
        public int InvItemId { get; set; }
        public DateTime DateStocked { get; set; }
        public DateTime ExpiryDate { get; set; }

        public InventoryItem InventoryItem { get; set; }
    }
}
