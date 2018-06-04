using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class Supplier
    {
        [Key]
        public int SupID { get; set; }
        public string Company { get; set; }
        public string ContacName { get; set; }
        public string ContactTitle { get; set; }
        public string PhoneNumber { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string SupplierCurrency { get; set; }
        public string AccountNumber { get; set; }
        public string BankInfo { get; set; }
        public string PaymentTerm { get; set; }
        public string Grade { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
        //public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
