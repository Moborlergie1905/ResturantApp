using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturantApp.BOL;
using ResturantApp.DAL;
using Repository.Interfaces;
using System.Data.Entity;

namespace Repository.Repositories
{
    public class SalesInvoiceRepository : Repository<SalesInvoice>, ISalesInvoiceRepository
    {
        public SalesInvoiceRepository(RestaurantContext context)
            : base(context)
        {
        }
    }
}
