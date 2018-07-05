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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(RestaurantContext context) 
            : base(context)
        {
        }
    }
}
