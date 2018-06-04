using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class MeasurementUnit
    {
        [Key]
        public int UnitID { get; set; }
        public string UnitName { get; set; }
    }
}
