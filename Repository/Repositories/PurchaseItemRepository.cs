using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturantApp.BOL;
using ResturantApp.DAL;
using Repository.Interfaces;

namespace Repository.Repositories
{
    class PurchaseItemRepository : Repository<PurchaseItem>, IPurchaseItemRepository
    {
        public PurchaseItemRepository(RestaurantContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PurchaseItem>> GetItems(int pId)
        {
            return await RestaurantContext.PurchaseItem.Where(x => x.PurchaseId == pId).ToListAsync();
        }

        public RestaurantContext RestaurantContext
        {
            get { return Context as RestaurantContext; }
        }
    }
}
