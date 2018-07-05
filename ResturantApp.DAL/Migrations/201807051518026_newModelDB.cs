namespace ResturantApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newModelDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "GroupID", "dbo.Category");
            DropForeignKey("dbo.Production", "ProdTypeId", "dbo.ProductionType");
            DropIndex("dbo.Product", new[] { "GroupID" });
            DropIndex("dbo.Production", new[] { "ProdTypeId" });
            AddColumn("dbo.InventoryItem", "ProdID", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "Class", c => c.Int(nullable: false));
            AddColumn("dbo.Production", "ProductionType", c => c.Int(nullable: false));
            CreateIndex("dbo.InventoryItem", "ProdID");
            AddForeignKey("dbo.InventoryItem", "ProdID", "dbo.Product", "ProdID");
            DropColumn("dbo.InventoryItem", "OtherDescription");
            DropColumn("dbo.Product", "UnitPrice");
            DropColumn("dbo.Product", "GroupID");
            DropColumn("dbo.Production", "ProdTypeId");
            DropTable("dbo.ProductionType");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductionType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProdType = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Production", "ProdTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "GroupID", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.InventoryItem", "OtherDescription", c => c.String());
            DropForeignKey("dbo.InventoryItem", "ProdID", "dbo.Product");
            DropIndex("dbo.InventoryItem", new[] { "ProdID" });
            DropColumn("dbo.Production", "ProductionType");
            DropColumn("dbo.Product", "Class");
            DropColumn("dbo.InventoryItem", "ProdID");
            CreateIndex("dbo.Production", "ProdTypeId");
            CreateIndex("dbo.Product", "GroupID");
            AddForeignKey("dbo.Production", "ProdTypeId", "dbo.ProductionType", "ID");
            AddForeignKey("dbo.Product", "GroupID", "dbo.Category", "CatID");
        }
    }
}
