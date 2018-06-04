using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ISalesInvoiceItemRepository : IRepository<SalesInvoiceItem>
    {
        Task<IEnumerable<SalesInvoiceItem>> GetItems(int pId);
    }
}
