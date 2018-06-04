using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;
using ResturantApp.DAL;
using Repository.Repositories;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantContext _context;

        public UnitOfWork(RestaurantContext context)
        {
            _context = context;
            Adjustments = new AdjustmentRepository(_context);
            AdjustmentsItems = new AdjustmentItemRepository(_context);
            Branches = new BranchRepository(_context);
            Categories = new CategoryRepository(_context);
            Customers = new CustomerRepository(_context);
            Deliveries = new DeliveryRepository(_context);
            DeliveryItems = new DeliveryItemRepository(_context);
            Divisions = new DivisionRepository(_context);
            Expirations = new ExpirationRepository(_context);
            Groups = new GroupRepository(_context);
            Stocks = new InventoryItemRepository(_context);
            Locations = new LocationRepository(_context);
            Units = new MeasurementUnitRepository(_context);
            Productions = new ProductionRepository(_context);
            Ingredients = new ProductionItemRepository(_context);
            ProductionTypes = new ProductionTypeRepository(_context);
            Purchases = new PurchaseRepository(_context);
            PurchaseItems = new PurchaseItemRepository(_context);
            PurchaseOrders = new PurchaseOrderRepository(_context);
            PurchaseOrderItems = new PurchaseOrderItemRepository(_context);
            SalesInvoices = new SalesInvoiceRepository(_context);
            SalesInvoiceItems = new SalesInvoiceItemRepository(_context);
            Suppliers = new SupplierRepository(_context);
            Transfers = new TransferRepository(_context);
            TransferItems = new TransferItemRepository(_context);
            Wastages = new WastageRepository(_context);
            WastageItems = new WastageItemRepository(_context);
            Workers = new WorkerRepository(_context);
        }

        public IAdjustmentRepository Adjustments { get; private set; }           

        public IAdjustmentItemRepository AdjustmentsItems { get; private set; }

        public IBranchRepository Branches { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public ICustomerRepository Customers { get; private set; }

        public IDeliveryRepository Deliveries { get; private set; }

        public IDeliveryItemRepository DeliveryItems { get; private set; }

        public IDivisionRepository Divisions { get; private set; }

        public IExpirationRepository Expirations { get; private set; }

        public IGroupRepository Groups { get; private set; }

        public IProductionItemRepository Ingredients { get; private set; }

        public ILocationRepository Locations { get; private set; }

        public IProductionRepository Productions { get; private set; }

        public IProductionTypeRepository ProductionTypes { get; private set; }

        public IPurchaseItemRepository PurchaseItems { get; private set; }

        public IPurchaseOrderItemRepository PurchaseOrderItems { get; private set; }

        public IPurchaseOrderRepository PurchaseOrders { get; private set; }

        public IPurchaseRepository Purchases { get; private set; }

        public ISalesInvoiceItemRepository SalesInvoiceItems { get; private set; }

        public ISalesInvoiceRepository SalesInvoices { get; private set; }

        public IInventoryItemRepository Stocks { get; private set; }

        public ISupplierRepository Suppliers { get; private set; }

        public ITransferItemRepository TransferItems { get; private set; }

        public ITransferRepository Transfers { get; private set; }

        public IMeasurementUnitRepository Units { get; private set; }

        public IWastageItemRepository WastageItems { get; private set; }

        public IWastageRepository Wastages { get; private set; }

        public IWorkerRepository Workers { get; private set; }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
