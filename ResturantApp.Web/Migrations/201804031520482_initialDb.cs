namespace ResturantApp.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        ItemId = c.String(nullable: false, maxLength: 128),
                        CartId = c.String(),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CatID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CatID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProdID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImagePath = c.String(),
                        CatID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdID)
                .ForeignKey("dbo.Categories", t => t.CatID, cascadeDelete: true)
                .Index(t => t.CatID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OnThisDay = c.DateTime(nullable: false),
                        ProdID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProdID, cascadeDelete: true)
                .Index(t => t.ProdID);
            
            CreateTable(
                "dbo.Productions",
                c => new
                    {
                        ProductionID = c.Int(nullable: false, identity: true),
                        ProdID = c.Int(nullable: false),
                        rStockID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitType = c.String(),
                        Detail = c.String(),
                        DatePrepared = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductionID)
                .ForeignKey("dbo.Products", t => t.ProdID, cascadeDelete: true)
                .ForeignKey("dbo.RawStocks", t => t.rStockID, cascadeDelete: true)
                .Index(t => t.ProdID)
                .Index(t => t.rStockID);
            
            CreateTable(
                "dbo.RawStocks",
                c => new
                    {
                        StockID = c.Int(nullable: false, identity: true),
                        GoodsName = c.String(),
                        UnitType = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.StockID);
            
            CreateTable(
                "dbo.Sales",
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
                .ForeignKey("dbo.Workers", t => t.WorkerID, cascadeDelete: true)
                .Index(t => t.WorkerID);
            
            CreateTable(
                "dbo.SaleDetails",
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
                .ForeignKey("dbo.Products", t => t.ProdID, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.SaleID, cascadeDelete: true)
                .Index(t => t.SaleID)
                .Index(t => t.ProdID);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        WorkerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.WorkerID);
            
            CreateTable(
                "dbo.FinishedStocks",
                c => new
                    {
                        StockID = c.Int(nullable: false, identity: true),
                        prodID = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitType = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateSocked = c.DateTime(nullable: false),
                        StockLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.StockID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "WorkerID", "dbo.Workers");
            DropForeignKey("dbo.SaleDetails", "SaleID", "dbo.Sales");
            DropForeignKey("dbo.SaleDetails", "ProdID", "dbo.Products");
            DropForeignKey("dbo.Productions", "rStockID", "dbo.RawStocks");
            DropForeignKey("dbo.Productions", "ProdID", "dbo.Products");
            DropForeignKey("dbo.Menus", "ProdID", "dbo.Products");
            DropForeignKey("dbo.Products", "CatID", "dbo.Categories");
            DropIndex("dbo.SaleDetails", new[] { "ProdID" });
            DropIndex("dbo.SaleDetails", new[] { "SaleID" });
            DropIndex("dbo.Sales", new[] { "WorkerID" });
            DropIndex("dbo.Productions", new[] { "rStockID" });
            DropIndex("dbo.Productions", new[] { "ProdID" });
            DropIndex("dbo.Menus", new[] { "ProdID" });
            DropIndex("dbo.Products", new[] { "CatID" });
            DropTable("dbo.FinishedStocks");
            DropTable("dbo.Workers");
            DropTable("dbo.SaleDetails");
            DropTable("dbo.Sales");
            DropTable("dbo.RawStocks");
            DropTable("dbo.Productions");
            DropTable("dbo.Menus");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Carts");
        }
    }
}
