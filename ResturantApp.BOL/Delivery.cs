using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class Delivery
    {
        [Key]
        public int DeliveryID { get; set; }
        [ForeignKey("Location")]
        public int TransFrom { get; set; }
        [ForeignKey("Customer")]
        public int DeliveryTo { get; set; }
        public DateTime DeliveryDate { get; set; }

        public virtual ICollection<DeliveryItem> DeliveryItems { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
    }
}
