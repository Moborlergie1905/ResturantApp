using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Name")]
        [Required(ErrorMessage = "Enter unit name")]
        public string UnitName { get; set; }
        [DisplayName("Unit")]
        [Required(ErrorMessage = "Enter unit name")]
        public string Notation { get; set; }
    }
}
