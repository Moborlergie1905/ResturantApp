using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class Location
    {
        [Key]
        public int LocID { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }

        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
