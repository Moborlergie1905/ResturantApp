namespace ResturantApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adjustStocktbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InventoryItem", "Unit_UnitID", c => c.Int());
            AddColumn("dbo.Product", "Description", c => c.String());
            AddColumn("dbo.StockHistory", "DateStocked", c => c.DateTime(nullable: false));
            AddColumn("dbo.StockHistory", "Quantity", c => c.Int(nullable: false));
            CreateIndex("dbo.InventoryItem", "Unit_UnitID");
            AddForeignKey("dbo.InventoryItem", "Unit_UnitID", "dbo.MeasurementUnit", "UnitID");
            DropColumn("dbo.InventoryItem", "Description");
            DropColumn("dbo.InventoryItem", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InventoryItem", "ImagePath", c => c.String());
            AddColumn("dbo.InventoryItem", "Description", c => c.String());
            DropForeignKey("dbo.InventoryItem", "Unit_UnitID", "dbo.MeasurementUnit");
            DropIndex("dbo.InventoryItem", new[] { "Unit_UnitID" });
            DropColumn("dbo.StockHistory", "Quantity");
            DropColumn("dbo.StockHistory", "DateStocked");
            DropColumn("dbo.Product", "Description");
            DropColumn("dbo.InventoryItem", "Unit_UnitID");
        }
    }
}
