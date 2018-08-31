using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantApp.Web.ViewModel
{
    public class ItemVM
    {
        public InventoryItem Item { get; set; }
        public Location Location { get; set; }
        public Expiration Expiry { get; set; }
    }
}