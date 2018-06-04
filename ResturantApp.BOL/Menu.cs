using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class Menu
    {
        //Available menu daily
        public int ID { get; set; }
        public DateTime OnThisDay { get; set; }
        [ForeignKey("Product")]
        public int ProdID { get; set; }
        public int Quantity { get; set; }
        
        public virtual Product Product { get; set; }
    }
}
