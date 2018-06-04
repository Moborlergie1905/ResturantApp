using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class Adjustment
    {
        [Key]
        public int ID { get; set; }
        public DateTime AdjDate { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<AdjustmentItem> AdjustmentItem { get; set; }
    }
}
