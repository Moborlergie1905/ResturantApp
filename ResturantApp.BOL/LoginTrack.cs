using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class LoginTrack
    {
        public int ID { get; set; }
        public int WorkerId { get; set; }
        public DateTime TimeIN { get; set; }
        public DateTime TimeOUT { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
