using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class SalesInvoice
    {
        [Key]
        public int InvoiceID { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public string RefNum { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public decimal Markup { get; set; }
        public decimal Discount { get; set; }
        public DateTime DateIssued { get; set; }
        public string Note { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<SalesInvoiceItem> SalesInventoryItems { get; set; }
    }
}
