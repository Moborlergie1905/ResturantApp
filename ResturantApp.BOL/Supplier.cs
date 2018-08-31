using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturantApp.BOL.Enums;

namespace ResturantApp.BOL
{
    public class Supplier
    {
        [Key]
        public int SupID { get; set; }
        public string Company { get; set; }
        [DisplayName("Contact name")]
        public string ContacName { get; set; }
        [DisplayName("Contact title")]
        public string ContactTitle { get; set; }
        [DisplayName("Telephone")]
        public string PhoneNumber { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        [ForeignKey("Currency")]
        [DisplayName("Currency")]
        public int SupplierCurrency { get; set; }
        [DisplayName("Account number")]
        public string AccountNumber { get; set; }
        [DisplayName("Bank info")]
        public string BankInfo { get; set; }
        [DisplayName("Payment term")]
        public string PaymentTerm { get; set; }
        public Grade Grade { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual Currency Currency { get; set; }
        //public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
