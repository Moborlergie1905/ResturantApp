using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;
using ResturantApp.BOL;
using ResturantApp.DAL;

namespace Repository.Repositories
{
    public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(RestaurantContext context)
           : base(context)
        {
        }
    }
}
