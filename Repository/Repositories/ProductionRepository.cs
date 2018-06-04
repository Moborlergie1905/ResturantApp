using ResturantApp.BOL;
using ResturantApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class ProductionRepository : Repository<Production>, IProductionRepository
    {
        public ProductionRepository(RestaurantContext context) 
            : base(context)
        {
        }
    }
}
