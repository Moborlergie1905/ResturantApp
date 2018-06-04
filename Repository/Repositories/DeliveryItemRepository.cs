using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Repository.Interfaces;
using ResturantApp.DAL;

namespace Repository.Repositories
{
    public class DeliveryItemRepository : Repository<DeliveryItem>, IDeliveryItemRepository
    {
        public DeliveryItemRepository(RestaurantContext context) 
            : base(context)
        {
        }

        public IEnumerable<DeliveryItem> GetItems(int pId)
        {
            return RestaurantContext.DeliveryItem.Where(x => x.DeliveryId == pId).ToList();
        }

        public RestaurantContext RestaurantContext
        {
            get { return Context as RestaurantContext; }
        }
    }
}
