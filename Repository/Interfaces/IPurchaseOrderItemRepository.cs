using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPurchaseOrderItemRepository : IRepository<PurchaseOrderItem>
    {
        IEnumerable<PurchaseOrderItem> GetItems(int pId);
    }
}
