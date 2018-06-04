using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturantApp.BOL;
using ResturantApp.DAL;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class ProductionTypeRepository : Repository<ProductionType>, IProductionTypeRepository
    {
        public ProductionTypeRepository(RestaurantContext context) 
            : base(context)
        {
        }
    }
}
