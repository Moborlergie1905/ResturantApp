using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ResturantApp.BOL
{
    public class InventoryItem
    {
        public InventoryItem()
        {
            Locations = new HashSet<Location>();           
        }
        [Key]
        public int ItemID { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        [Display(Name = "Product code")]
        public string ProductCode { get; set; }
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        [ForeignKey("Product"), DisplayName("Product")]
        public int ProdID { get; set; }
        [Display(Name = "Buying format")]
        public string BuyingFormat { get; set; }
        [Display(Name = "Inventory format")]
        public string InventoryFormat { get; set; }
        [Display(Name = "Usage format")]
        public string UsageFormat { get; set; }
        [Display(Name = "Packaging format")]
        public string PackagingFormat { get; set; }
        [Display(Name = "Unit price")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Average price")]
        public decimal AveragePrice { get; set; } 
        [Display(Name = "Selling price")]       
        public decimal SellingPrice { get; set; }       
        public int Quantity { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        [Display(Name = "Date stocked")]
        public DateTime DateStocked { get; set; }
        public byte IsExpiry { get; set; }   
        public byte HideInReport { get; set; }
        public byte Disconitued { get; set; }
        public string ImagePath { get; set; }
       
        public virtual Group Group { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Expiration> Expiration { get; set; }
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } 
        public virtual Product Product { get; set; }       
    }
}
