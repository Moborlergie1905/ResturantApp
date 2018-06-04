using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int WorkerID { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountTendered { get; set; }
        public decimal Balance { get; set; }
        public decimal VAT { get; set; }
        public DateTime SaleTime { get; set; }

        public virtual Worker Worker { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
