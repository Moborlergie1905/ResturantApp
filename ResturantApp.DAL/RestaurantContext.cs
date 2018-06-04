using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ResturantApp.DAL
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext() : base("RestaurantContext")
        { }
      
        public DbSet<Cart> CartItem { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }       
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Production> Production { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<SaleDetail> SaleDetail { get; set; }
        public DbSet<Worker> Worker { get; set; }
        public DbSet<Adjustment> Adjustment { get; set; }
        public DbSet<AdjustmentItem> AdjustmentItem { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<DeliveryItem> DeliveryItem { get; set; }
        public DbSet<Division> Division { get; set; }
        public DbSet<Expiration> Expiration { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<InventoryItem> InventoryItem { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<MeasurementUnit> Unit { get; set; }
        public DbSet<ProductionIngredient> ProductionItem { get; set; }
        public DbSet<ProductionType> ProductionType { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<PurchaseItem> PurchaseItem { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItem { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<SalesInvoice> SalesInvoice { get; set; }
        public DbSet<SalesInvoiceItem> SalesInvoiceItem { get; set; }
        public DbSet<Transfer> Transfer { get; set; }
        public DbSet<TransferItem> TransferItem { get; set; }
        public DbSet<Wastage> Wastage { get; set; }
        public DbSet<WastageItem> WastageItem { get; set; }
        public DbSet<LoginTrack> LoginTrack { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Location>()
                .HasMany<InventoryItem>(i => i.InventoryItems)
                .WithRequired(l => l.Location)
                .WillCascadeOnDelete();           
            //modelBuilder.Entity<InventoryItem>()
            //    .HasRequired(x => x.Location)
            //    .WithRequiredDependent()
            //    .WillCascadeOnDelete(false);
            //foreach (var relationship in modelBuilder..Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            ////}
            //base.OnModelCreating(modelBuilder);

        }

    }
}
