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
    public class SalesInvoiceItemRepository : Repository<SalesInvoiceItem>, ISalesInvoiceItemRepository
    {
        public SalesInvoiceItemRepository(RestaurantContext context) 
            : base(context)
        {
        }

        public async Task<IEnumerable<SalesInvoiceItem>> GetItems(int pId)
        {
            return await RestaurantContext.SalesInvoiceItem.Where(x => x.SaleInvId == pId).ToListAsync();
        }

        public RestaurantContext RestaurantContext
        {
            get { return Context as RestaurantContext; }
        }
    }
}
