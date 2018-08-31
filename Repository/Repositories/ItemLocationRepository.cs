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
    public class ItemLocationRepository : Repository<ItemLocation>, IItemLocationRepository
    {
        public ItemLocationRepository(RestaurantContext context) 
            : base(context)
        {
        }
    }
}
