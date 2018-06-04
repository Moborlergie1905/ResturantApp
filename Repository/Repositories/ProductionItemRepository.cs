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
    public class ProductionItemRepository : Repository<ProductionIngredient>, IProductionItemRepository
    {
        public ProductionItemRepository(RestaurantContext context) 
            : base(context)
        {
        }

        public async Task<IEnumerable<ProductionIngredient>> GetItems(int pId)
        {
            return await RestaurantContext.ProductionItem.Where(x => x.ProdId == pId).ToListAsync();
        }

        public RestaurantContext RestaurantContext
        {
            get { return Context as RestaurantContext; }
        }
    }
}
