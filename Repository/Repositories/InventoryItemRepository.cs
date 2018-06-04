using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ResturantApp.DAL;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class InventoryItemRepository : Repository<InventoryItem>, IInventoryItemRepository
    {
        public InventoryItemRepository(RestaurantContext context) : base(context)
        {
        }

        public async Task<IEnumerable<InventoryItem>> GetByLocation(int id)
        {
            return await RestaurantContext.InventoryItem.Where(x => x.LocationId == id).ToListAsync();
        }

        public RestaurantContext RestaurantContext
        {
            get { return Context as RestaurantContext; }
        }
    }
}
