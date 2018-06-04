using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturantApp.BOL;

namespace Repository.Interfaces
{
    public interface IProductionItemRepository : IRepository<ProductionIngredient>
    {
        Task<IEnumerable<ProductionIngredient>> GetItems(int pId);
    }
}
