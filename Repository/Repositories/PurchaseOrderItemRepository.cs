using Repository.Interfaces;
using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ResturantApp.DAL;

namespace Repository.Repositories
{
    public class PurchaseOrderItemRepository : Repository<PurchaseOrderItem>, IPurchaseOrderItemRepository
    {
        public PurchaseOrderItemRepository(RestaurantContext context) 
            : base(context)
        {
        }

        public IEnumerable<PurchaseOrderItem> GetItems(int pId)
        {
            return RestaurantContext.PurchaseOrderItem.Where(x => x.PurchOrderId == pId);
        }
        public RestaurantContext RestaurantContext
        {
            get { return Context as RestaurantContext; }
        }
    }
}
