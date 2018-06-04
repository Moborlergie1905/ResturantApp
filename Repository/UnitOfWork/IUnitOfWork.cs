using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAdjustmentRepository Adjustments { get; }
        IAdjustmentItemRepository AdjustmentsItems { get; }
        IBranchRepository Branches { get; }
        ICategoryRepository Categories { get; }
        ICustomerRepository Customers { get; }
        IDeliveryRepository Deliveries { get; }
        IDeliveryItemRepository DeliveryItems { get; }
        IDivisionRepository Divisions { get; }
        IExpirationRepository Expirations { get; }
        IGroupRepository Groups { get; }
        IInventoryItemRepository Stocks { get; }
        ILocationRepository Locations { get; }
        IMeasurementUnitRepository Units { get; }
        IProductionRepository Productions { get; }
        IProductionItemRepository Ingredients { get; }
        IProductionTypeRepository ProductionTypes { get; }
        IPurchaseRepository Purchases { get; }
        IPurchaseItemRepository PurchaseItems { get; }
        IPurchaseOrderRepository PurchaseOrders { get; }
        IPurchaseOrderItemRepository PurchaseOrderItems { get; }
        ISalesInvoiceRepository SalesInvoices { get; }
        ISalesInvoiceItemRepository SalesInvoiceItems { get; }
        ISupplierRepository Suppliers { get; }
        ITransferRepository Transfers { get; }
        ITransferItemRepository TransferItems { get; }
        IWastageRepository Wastages { get; }
        IWastageItemRepository WastageItems { get; }
        IWorkerRepository Workers { get; }
        Task<int> Complete();
    }
}
