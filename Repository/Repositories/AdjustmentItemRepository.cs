using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ResturantApp.DAL;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace Repository.Repositories
{
    public class AdjustmentItemRepository : Repository<AdjustmentItem>, IAdjustmentItemRepository
    {
        public AdjustmentItemRepository(RestaurantContext context) 
            : base(context)
        {
        }

        public IEnumerable<AdjustmentItem> GetItems(int adjId)
        {
            return RestaurantContext.AdjustmentItem.Where(x => x.AdjId == adjId).ToList();
        }

        public RestaurantContext RestaurantContext
        {
            get { return Context as RestaurantContext; }
        }       
    }
}
