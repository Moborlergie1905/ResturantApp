using System.Data.Entity;
using ResturantApp.BOL;
using ResturantApp.DAL;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Repository.Repositories
{
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(RestaurantContext context) 
            : base(context)
        {
        }

        public async Task<IEnumerable<Purchase>> GetBySupplier(int id)
        {
            return await RestaurantContext.Purchase.Where(x => x.SupplierId == id).ToListAsync();
        }

        public RestaurantContext RestaurantContext
        {
            get { return Context as RestaurantContext; }
        }
    }
}
