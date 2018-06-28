using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class InventoryItem
    {
        public InventoryItem()
        {
            this.Locations = new HashSet<Location>();
        }
        [Key]
        public int ItemID { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public string OtherDescription { get; set; }
        public string Barcode { get; set; }
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        //[ForeignKey("Supplier")]
        //public int SupplierId { get; set; }
        public string BuyingFormat { get; set; }
        public string InventoryFormat { get; set; }
        public string UsageFormat { get; set; }
        public string PackagingFormat { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal AveragePrice { get; set; }        
        public decimal SellingPrice { get; set; }
        //[Required]
        //[ForeignKey("Location")]
        //public int LocationId { get; set; }
        public int Quantity { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public DateTime DateStocked { get; set; }
        public byte IsExpiry { get; set; }   
        public byte HideInReport { get; set; }
        public byte Disconitued { get; set; }
        public string ImagePath { get; set; }

        //public virtual Supplier Supplier { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Expiration> Expiration { get; set; }
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
