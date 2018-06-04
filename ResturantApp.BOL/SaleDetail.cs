using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class SaleDetail
    {
        [Key]
        public string sDetailID { get; set; }
        public int SaleID { get; set; }
        [ForeignKey("Product")]
        public int ProdID { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        //public int WorkerID { get; set; }
        public DateTime TimeSold { get; set; }

        //public virtual Worker Worker { get; set; }
        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
