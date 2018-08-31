using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class Currency
    {
        public int ID { get; set; }
        [DisplayName("Currency")]
        public string CurrencyType { get; set; }
        public string Description { get; set; }
    }
}
