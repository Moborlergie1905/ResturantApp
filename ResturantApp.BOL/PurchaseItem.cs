﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class PurchaseItem
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Purchase"), Display(Name = "Purchase Id")]
        public int PurchaseId { get; set; }
        [ForeignKey("InverntoryItem"), Display(Name = "Item")]
        public int InventItemId { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("MeasurementUnit")]
        public int Unit { get; set; }
        public decimal price { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }        
        //[ForeignKey("Location")]
        //public int LocationId { get; set; }

        public virtual Purchase Purchase { get; set; }
        public virtual InventoryItem InverntoryItem { get; set; }
        public virtual MeasurementUnit MeasurementUnit { get; set; }
        //public virtual Location Location { get; set; }
    }
}
