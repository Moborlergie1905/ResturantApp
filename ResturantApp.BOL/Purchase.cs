using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class Purchase
    {
        [Key]
        public int PurchID { get; set; }
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public decimal Discount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Note { get; set; }
        public decimal TotalFreight { get; set; }
        public decimal OtherCost { get; set; }
        public decimal TotalCustom { get; set; }
        public decimal Tax { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
