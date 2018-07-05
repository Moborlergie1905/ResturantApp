using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ResturantApp.BOL
{
    public class Product
    {
        [Key]
        public int ProdID { get; set; }       
        public string Name { get; set; }  
        public ProductType Class { get; set; }             
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public Product()
        {
            ImagePath = "~/AppFiles/ProductImages/default.png";
        }

    }
}
