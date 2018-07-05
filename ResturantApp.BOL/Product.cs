using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class Product
    {
        [Key]
        public int ProdID { get; set; }  
        public string ProductCode { get; set; }      
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImagePath { get; set; }
        [ForeignKey("Group")]
        public int GroupID { get; set; }

        public virtual Group Group { get; set; }
    }
}
