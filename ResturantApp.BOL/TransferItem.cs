﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class TransferItem
    {
        [Key]
        public int ID { get; set; }
        public int TransId { get; set; }
        public int InvItemId { get; set; }
        public int AvailQty { get; set; }
        public int Qty { get; set; }
        [ForeignKey("MeasurementUnit")]
        public int Unit { get; set; }
        public decimal UnitCost { get; set; }
        public decimal TotalCost { get; set; }

        public virtual MeasurementUnit MeasurementUnit { get; set; }
    }
}
