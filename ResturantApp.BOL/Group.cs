using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class Group
    {
        [Key]
        public int GpID { get; set; }
        public string Name { get; set; }
        [ForeignKey("Division")]
        public int divID { get; set; }
        [DisplayName("Asset A/C")]
        public decimal? AssetAccount { get; set; }
        [DisplayName("Revenue A/C")]
        public decimal? RevenueAccount { get; set; }
        [DisplayName("Expenses A/C")]
        public decimal? ExpensesAccount { get; set; }
        [DisplayName("Adjustment A/C")]
        public decimal? AdjustmentAccount { get; set; }
        public bool Tax1 { get; set; }
        public bool Tax2 { get; set; }
        public bool Tax3 { get; set; }
        public string Markup { get; set; }

        public virtual Division Division { get; set; }

        public Group()
        {
            Tax1 = false;
            Tax2 = false;
            Tax3 = false;
            AssetAccount = 0;
            RevenueAccount = 0;
            ExpensesAccount = 0;
            AdjustmentAccount = 0;
        }
    }
}
