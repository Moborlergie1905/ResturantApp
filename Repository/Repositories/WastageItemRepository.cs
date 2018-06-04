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
    public class WastageItemRepository : Repository<WastageItem>, IWastageItemRepository
    {
        public WastageItemRepository(RestaurantContext context) : base(context)
        {
        }

        public IEnumerable<WastageItem> GetItems(int pId)
        {
            return RestaurantContext.WastageItem.Where(x => x.WastageId == pId);
        }

        public RestaurantContext RestaurantContext
        {
            get { return Context as RestaurantContext; }
        }
    }
}
