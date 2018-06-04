using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class Transfer
    {
        [Key]
        public int TransID { get; set; }
        public string TransFrom { get; set; }
        public string TransTo { get; set; }
        public DateTime TransDate { get; set; }
    }
}
