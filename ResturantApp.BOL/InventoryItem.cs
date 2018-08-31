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
            DateStocked = DateTime.Now;          
        }
        [Key]
        public int ItemID { get; set; }
        public string Barcode { get; set; }       
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
        [DisplayName("Is Expiry?")]
        public bool IsExpiry { get; set; }   
        [DisplayName("Hide in Report?")]
        public bool HideInReport { get; set; }
        [DisplayName("Discontinued")]
        public bool Disconitued { get; set; }       
       
        public virtual Group Group { get; set; }
        public virtual ICollection<ItemLocation> ItemLocations { get; set; }
        public virtual ICollection<Expiration> Expiration { get; set; }
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } 
        public virtual Product Product { get; set; }  
        public virtual ICollection<StockHistory> Logs { get; set; }
        public virtual MeasurementUnit Unit { get; set; }
    }
}
