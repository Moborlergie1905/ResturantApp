using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using ResturantApp.BOL.Enums;

namespace ResturantApp.BOL
{
    public class Product
    {
        [Key]
        public int ProdID { get; set; }  
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public ProductType Class { get; set; }  
        [DisplayName("Image")]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public Product()
        {
            ImagePath = "~/AppFiles/ProductImages/default.png";
        }

    }
}
