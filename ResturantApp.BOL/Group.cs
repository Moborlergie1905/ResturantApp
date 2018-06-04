using System;
using System.Collections.Generic;
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
        public decimal? AssetAccount { get; set; }
        public decimal? RevenueAccount { get; set; }
        public decimal? ExpensesAccount { get; set; }
        public decimal? AdjustmentAccount { get; set; }
        public decimal? Tax1 { get; set; }
        public decimal? Tax2 { get; set; }
        public decimal? Tax3 { get; set; }
        public string Markup { get; set; }

        public virtual Division Division { get; set; }
    }
}
