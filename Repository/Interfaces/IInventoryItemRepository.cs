using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IInventoryItemRepository : IRepository<InventoryItem>
    {
        //Task<IEnumerable<InventoryItem>> GetByLocation(int id);
    }
}
