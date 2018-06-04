using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantApp.Web.Models
{
    public class InvoiceModel
    {
        public SalesInvoice Invoice { get; set; }
        public List<SalesInvoiceItem> Items { get; set; }
    }
}