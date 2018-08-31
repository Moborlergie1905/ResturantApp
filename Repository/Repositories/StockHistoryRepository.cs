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
    public class StockHistoryRepository : Repository<StockHistory>, IStockHistoryRepository
    {
        public StockHistoryRepository(RestaurantContext context) 
            : base(context)
        {
        }
    }
}
