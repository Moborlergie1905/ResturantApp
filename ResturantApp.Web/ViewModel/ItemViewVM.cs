using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantApp.Web.ViewModel
{
    public class ItemViewVM
    {
        public InventoryItem Item { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<Expiration> Expiries { get; set; }
    }
}