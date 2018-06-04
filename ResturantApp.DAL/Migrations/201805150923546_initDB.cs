namespace ResturantApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adjustment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdjDate = c.DateTime(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Location", t => t.LocationId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.AdjustmentItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdjId = c.Int(nullable: false),
                        InvItemId = c.Int(nullable: false),
                        QtyOH = c.Int(nullable: false),
                        Variance = c.Int(nullable: false),
                        NewQty = c.Int(nullable: false),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Adjustment", t => t.AdjId)
                .ForeignKey("dbo.InventoryItem", t => t.InvItemId)
                .Index(t => t.AdjId)
                .Index(t => t.InvItemId);
            
            CreateTable(
                "dbo.InventoryItem",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(),
                        Description = c.String(),
                        OtherDescription = c.String(),
                        Barcode = c.String(),
                        GroupId = c.Int(nullable: false),
                        BuyingFormat = c.String(),
                        InventoryFormat = c.String(),
                        UsageFormat = c.String(),
                        PackagingFormat = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AveragePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LocationId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Min = c.Int(nullable: false),
                        Max = c.Int(nullable: false),
                        DateStocked = c.DateTime(nullable: false),
                        IsExpiry = c.Byte(nullable: false),
                        HideInReport = c.Byte(nullable: false),
                        Disconitued = c.Byte(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Group", t => t.GroupId)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Expiration",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InvItemId = c.Int(nullable: false),
                        DateStocked = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InventoryItem", t => t.InvItemId)
                .Index(t => t.InvItemId);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        GpID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        divID = c.Int(nullable: false),
                        AssetAccount = c.Decimal(precision: 18, scale: 2),
                        RevenueAccount = c.Decimal(precision: 18, scale: 2),
                        ExpensesAccount = c.Decimal(precision: 18, scale: 2),
                        AdjustmentAccount = c.Decimal(precision: 18, scale: 2),
                        Tax1 = c.Decimal(precision: 18, scale: 2),
                        Tax2 = c.Decimal(precision: 18, scale: 2),
                        Tax3 = c.Decimal(precision: 18, scale: 2),
                        Markup = c.String(),
                    })
                .PrimaryKey(t => t.GpID)
                .ForeignKey("dbo.Division", t => t.divID)
                .Index(t => t.divID);
            
            CreateTable(
                "dbo.Division",
                c => new
                    {
                        divID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.divID)
                .ForeignKey("dbo.Category", t => t.CatId)
                .Index(t => t.CatId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CatID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CatID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Branch = c.String(),
                    })
                .PrimaryKey(t => t.LocID);
            
            CreateTable(
                "dbo.Branch",
                c => new
                    {
                        BranchID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BranchID);
            
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        ItemId = c.String(nullable: false, maxLength: 128),
                        CartId = c.String(),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CusID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Mobile = c.String(),
                        OfficePhone = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Remarks = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.CusID);
            
            CreateTable(
                "dbo.Delivery",
                c => new
                    {
                        DeliveryID = c.Int(nullable: false, identity: true),
                        TransFrom = c.Int(nullable: false),
                        DeliveryTo = c.Int(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DeliveryID)
                .ForeignKey("dbo.Customer", t => t.DeliveryTo)
                .ForeignKey("dbo.Location", t => t.TransFrom)
                .Index(t => t.TransFrom)
                .Index(t => t.DeliveryTo);
            
            CreateTable(
                "dbo.DeliveryItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DeliveryId = c.Int(nullable: false),
                        InvItemId = c.Int(nullable: false),
                        AvailQty = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Unit = c.String(),
                        UnitCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Delivery", t => t.DeliveryId)
                .ForeignKey("dbo.InventoryItem", t => t.InvItemId)
                .Index(t => t.DeliveryId)
                .Index(t => t.InvItemId);
            
            CreateTable(
                "dbo.LoginTrack",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WorkerId = c.Int(nullable: false),
                        TimeIN = c.DateTime(nullable: false),
                        TimeOUT = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Worker", t => t.WorkerId)
                .Index(t => t.WorkerId);
            
            CreateTable(
                "dbo.Worker",
                c => new
                    {
                        WorkerID = c.Int(nullable: false, identity: true),
                        IdCode = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.WorkerID);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OnThisDay = c.DateTime(nullable: false),
                        ProdID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.ProdID)
                .Index(t => t.ProdID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProdID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImagePath = c.String(),
                        GroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdID)
                .ForeignKey("dbo.Category", t => t.GroupID)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.Production",
                c => new
                    {
                        ProdID = c.Int(nullable: false, identity: true),
                        ProdTypeId = c.Int(nullable: false),
                        InvItemId = c.Int(nullable: false),
                        ProdDate = c.DateTime(nullable: false),
                        Qty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdID)
                .ForeignKey("dbo.InventoryItem", t => t.InvItemId)
                .ForeignKey("dbo.ProductionType", t => t.ProdTypeId)
                .Index(t => t.ProdTypeId)
                .Index(t => t.InvItemId);
            
            CreateTable(
                "dbo.ProductionIngredient",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProdId = c.Int(nullable: false),
                        InvItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UntitCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit = c.String(),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InventoryItem", t => t.InvItemId)
                .ForeignKey("dbo.Location", t => t.LocationId)
                .ForeignKey("dbo.Production", t => t.ProdId)
                .Index(t => t.ProdId)
                .Index(t => t.InvItemId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.ProductionType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProdType = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        PurchID = c.Int(nullable: false, identity: true),
                        SupplierId = c.Int(nullable: false),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        Note = c.String(),
                        TotalFreight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCustom = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PurchID)
                .ForeignKey("dbo.Supplier", t => t.SupplierId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.PurchaseItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PurchaseId = c.Int(nullable: false),
                        InventItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Unit = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InventoryItem", t => t.InventItemId)
                .ForeignKey("dbo.Purchase", t => t.PurchaseId)
                .Index(t => t.PurchaseId)
                .Index(t => t.InventItemId);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        SupID = c.Int(nullable: false, identity: true),
                        Company = c.String(),
                        ContacName = c.String(),
                        ContactTitle = c.String(),
                        PhoneNumber = c.String(),
                        Mobile = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        SupplierCurrency = c.String(),
                        AccountNumber = c.String(),
                        BankInfo = c.String(),
                        PaymentTerm = c.String(),
                        Grade = c.String(),
                    })
                .PrimaryKey(t => t.SupID);
            
            CreateTable(
                "dbo.PurchaseOrder",
                c => new
                    {
                        PurchOrderId = c.Int(nullable: false, identity: true),
                        SupplierId = c.Int(nullable: false),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        Note = c.String(),
                        TotalFreight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCustom = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderTracker = c.String(),
                        DeliveryStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchOrderId)
                .ForeignKey("dbo.Supplier", t => t.SupplierId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.PurchaseOrderItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PurchOrderId = c.Int(nullable: false),
                        InventItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Unit = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InventoryItem", t => t.InventItemId)
                .ForeignKey("dbo.Location", t => t.LocationId)
                .ForeignKey("dbo.PurchaseOrder", t => t.PurchOrderId)
                .Index(t => t.PurchOrderId)
                .Index(t => t.InventItemId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        SaleID = c.Int(nullable: false, identity: true),
                        WorkerID = c.Int(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountTendered = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VAT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SaleTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SaleID)
                .ForeignKey("dbo.Worker", t => t.WorkerID)
                .Index(t => t.WorkerID);
            
            CreateTable(
                "dbo.SaleDetail",
                c => new
                    {
                        sDetailID = c.String(nullable: false, maxLength: 128),
                        SaleID = c.Int(nullable: false),
                        ProdID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TimeSold = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.sDetailID)
                .ForeignKey("dbo.Product", t => t.ProdID)
                .ForeignKey("dbo.Sale", t => t.SaleID)
                .Index(t => t.SaleID)
                .Index(t => t.ProdID);
            
            CreateTable(
                "dbo.SalesInvoice",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        RefNum = c.String(),
                        LocationId = c.Int(nullable: false),
                        Markup = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateIssued = c.DateTime(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.Location", t => t.LocationId)
                .Index(t => t.CustomerId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.SalesInvoiceItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SaleInvId = c.Int(nullable: false),
                        InventItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Unit = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InventoryItem", t => t.InventItemId)
                .ForeignKey("dbo.SalesInvoice", t => t.SaleInvId)
                .Index(t => t.SaleInvId)
                .Index(t => t.InventItemId);
            
            CreateTable(
                "dbo.Transfer",
                c => new
                    {
                        TransID = c.Int(nullable: false, identity: true),
                        TransFrom = c.String(),
                        TransTo = c.String(),
                        TransDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransID);
            
            CreateTable(
                "dbo.TransferItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TransId = c.Int(nullable: false),
                        InvItemId = c.Int(nullable: false),
                        AvailQty = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Unit = c.String(),
                        UnitCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MeasurementUnit",
                c => new
                    {
                        UnitID = c.Int(nullable: false, identity: true),
                        UnitName = c.String(),
                    })
                .PrimaryKey(t => t.UnitID);
            
            CreateTable(
                "dbo.Wastage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WastageType = c.String(),
                        LocationId = c.Int(nullable: false),
                        WastageDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Location", t => t.LocationId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.WastageItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WastageId = c.Int(nullable: false),
                        InvItemId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Unit = c.String(),
                        UnitCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OldQtyOH = c.Int(nullable: false),
                        NewQtyOH = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InventoryItem", t => t.InvItemId)
                .ForeignKey("dbo.Wastage", t => t.WastageId)
                .Index(t => t.WastageId)
                .Index(t => t.InvItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WastageItem", "WastageId", "dbo.Wastage");
            DropForeignKey("dbo.WastageItem", "InvItemId", "dbo.InventoryItem");
            DropForeignKey("dbo.Wastage", "LocationId", "dbo.Location");
            DropForeignKey("dbo.SalesInvoiceItem", "SaleInvId", "dbo.SalesInvoice");
            DropForeignKey("dbo.SalesInvoiceItem", "InventItemId", "dbo.InventoryItem");
            DropForeignKey("dbo.SalesInvoice", "LocationId", "dbo.Location");
            DropForeignKey("dbo.SalesInvoice", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Sale", "WorkerID", "dbo.Worker");
            DropForeignKey("dbo.SaleDetail", "SaleID", "dbo.Sale");
            DropForeignKey("dbo.SaleDetail", "ProdID", "dbo.Product");
            DropForeignKey("dbo.PurchaseOrderItem", "PurchOrderId", "dbo.PurchaseOrder");
            DropForeignKey("dbo.PurchaseOrderItem", "LocationId", "dbo.Location");
            DropForeignKey("dbo.PurchaseOrderItem", "InventItemId", "dbo.InventoryItem");
            DropForeignKey("dbo.PurchaseOrder", "SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.Purchase", "SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.PurchaseItem", "PurchaseId", "dbo.Purchase");
            DropForeignKey("dbo.PurchaseItem", "InventItemId", "dbo.InventoryItem");
            DropForeignKey("dbo.Production", "ProdTypeId", "dbo.ProductionType");
            DropForeignKey("dbo.Production", "InvItemId", "dbo.InventoryItem");
            DropForeignKey("dbo.ProductionIngredient", "ProdId", "dbo.Production");
            DropForeignKey("dbo.ProductionIngredient", "LocationId", "dbo.Location");
            DropForeignKey("dbo.ProductionIngredient", "InvItemId", "dbo.InventoryItem");
            DropForeignKey("dbo.Menu", "ProdID", "dbo.Product");
            DropForeignKey("dbo.Product", "GroupID", "dbo.Category");
            DropForeignKey("dbo.LoginTrack", "WorkerId", "dbo.Worker");
            DropForeignKey("dbo.Delivery", "TransFrom", "dbo.Location");
            DropForeignKey("dbo.DeliveryItem", "InvItemId", "dbo.InventoryItem");
            DropForeignKey("dbo.DeliveryItem", "DeliveryId", "dbo.Delivery");
            DropForeignKey("dbo.Delivery", "DeliveryTo", "dbo.Customer");
            DropForeignKey("dbo.Adjustment", "LocationId", "dbo.Location");
            DropForeignKey("dbo.AdjustmentItem", "InvItemId", "dbo.InventoryItem");
            DropForeignKey("dbo.InventoryItem", "LocationId", "dbo.Location");
            DropForeignKey("dbo.InventoryItem", "GroupId", "dbo.Group");
            DropForeignKey("dbo.Group", "divID", "dbo.Division");
            DropForeignKey("dbo.Division", "CatId", "dbo.Category");
            DropForeignKey("dbo.Expiration", "InvItemId", "dbo.InventoryItem");
            DropForeignKey("dbo.AdjustmentItem", "AdjId", "dbo.Adjustment");
            DropIndex("dbo.WastageItem", new[] { "InvItemId" });
            DropIndex("dbo.WastageItem", new[] { "WastageId" });
            DropIndex("dbo.Wastage", new[] { "LocationId" });
            DropIndex("dbo.SalesInvoiceItem", new[] { "InventItemId" });
            DropIndex("dbo.SalesInvoiceItem", new[] { "SaleInvId" });
            DropIndex("dbo.SalesInvoice", new[] { "LocationId" });
            DropIndex("dbo.SalesInvoice", new[] { "CustomerId" });
            DropIndex("dbo.SaleDetail", new[] { "ProdID" });
            DropIndex("dbo.SaleDetail", new[] { "SaleID" });
            DropIndex("dbo.Sale", new[] { "WorkerID" });
            DropIndex("dbo.PurchaseOrderItem", new[] { "LocationId" });
            DropIndex("dbo.PurchaseOrderItem", new[] { "InventItemId" });
            DropIndex("dbo.PurchaseOrderItem", new[] { "PurchOrderId" });
            DropIndex("dbo.PurchaseOrder", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseItem", new[] { "InventItemId" });
            DropIndex("dbo.PurchaseItem", new[] { "PurchaseId" });
            DropIndex("dbo.Purchase", new[] { "SupplierId" });
            DropIndex("dbo.ProductionIngredient", new[] { "LocationId" });
            DropIndex("dbo.ProductionIngredient", new[] { "InvItemId" });
            DropIndex("dbo.ProductionIngredient", new[] { "ProdId" });
            DropIndex("dbo.Production", new[] { "InvItemId" });
            DropIndex("dbo.Production", new[] { "ProdTypeId" });
            DropIndex("dbo.Product", new[] { "GroupID" });
            DropIndex("dbo.Menu", new[] { "ProdID" });
            DropIndex("dbo.LoginTrack", new[] { "WorkerId" });
            DropIndex("dbo.DeliveryItem", new[] { "InvItemId" });
            DropIndex("dbo.DeliveryItem", new[] { "DeliveryId" });
            DropIndex("dbo.Delivery", new[] { "DeliveryTo" });
            DropIndex("dbo.Delivery", new[] { "TransFrom" });
            DropIndex("dbo.Division", new[] { "CatId" });
            DropIndex("dbo.Group", new[] { "divID" });
            DropIndex("dbo.Expiration", new[] { "InvItemId" });
            DropIndex("dbo.InventoryItem", new[] { "LocationId" });
            DropIndex("dbo.InventoryItem", new[] { "GroupId" });
            DropIndex("dbo.AdjustmentItem", new[] { "InvItemId" });
            DropIndex("dbo.AdjustmentItem", new[] { "AdjId" });
            DropIndex("dbo.Adjustment", new[] { "LocationId" });
            DropTable("dbo.WastageItem");
            DropTable("dbo.Wastage");
            DropTable("dbo.MeasurementUnit");
            DropTable("dbo.TransferItem");
            DropTable("dbo.Transfer");
            DropTable("dbo.SalesInvoiceItem");
            DropTable("dbo.SalesInvoice");
            DropTable("dbo.SaleDetail");
            DropTable("dbo.Sale");
            DropTable("dbo.Roles");
            DropTable("dbo.PurchaseOrderItem");
            DropTable("dbo.PurchaseOrder");
            DropTable("dbo.Supplier");
            DropTable("dbo.PurchaseItem");
            DropTable("dbo.Purchase");
            DropTable("dbo.ProductionType");
            DropTable("dbo.ProductionIngredient");
            DropTable("dbo.Production");
            DropTable("dbo.Product");
            DropTable("dbo.Menu");
            DropTable("dbo.Worker");
            DropTable("dbo.LoginTrack");
            DropTable("dbo.DeliveryItem");
            DropTable("dbo.Delivery");
            DropTable("dbo.Customer");
            DropTable("dbo.Cart");
            DropTable("dbo.Branch");
            DropTable("dbo.Location");
            DropTable("dbo.Category");
            DropTable("dbo.Division");
            DropTable("dbo.Group");
            DropTable("dbo.Expiration");
            DropTable("dbo.InventoryItem");
            DropTable("dbo.AdjustmentItem");
            DropTable("dbo.Adjustment");
        }
    }
}
