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
    public class TransferItemRepository : Repository<TransferItem>, ITransferItemRepository
    {
        public TransferItemRepository(RestaurantContext context) : base(context)
        {
        }

        public IEnumerable<TransferItem> GetItems(int pId)
        {
            return RestaurantContext.TransferItem.Where(x => x.TransId == pId);
        }

        public RestaurantContext RestaurantContext
        {
            get { return Context as RestaurantContext; }
        }
    }
}
