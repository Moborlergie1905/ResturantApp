namespace ResturantApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class plusItemLocationModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LocationInventoryItem", "Location_LocID", "dbo.Location");
            DropForeignKey("dbo.LocationInventoryItem", "InventoryItem_ItemID", "dbo.InventoryItem");
            DropIndex("dbo.LocationInventoryItem", new[] { "Location_LocID" });
            DropIndex("dbo.LocationInventoryItem", new[] { "InventoryItem_ItemID" });
            CreateTable(
                "dbo.ItemLocation",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        Min = c.Int(nullable: false),
                        Max = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InventoryItem", t => t.ItemId)
                .ForeignKey("dbo.Location", t => t.LocationId)
                .Index(t => t.ItemId)
                .Index(t => t.LocationId);
            
            DropTable("dbo.LocationInventoryItem");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LocationInventoryItem",
                c => new
                    {
                        Location_LocID = c.Int(nullable: false),
                        InventoryItem_ItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Location_LocID, t.InventoryItem_ItemID });
            
            DropForeignKey("dbo.ItemLocation", "LocationId", "dbo.Location");
            DropForeignKey("dbo.ItemLocation", "ItemId", "dbo.InventoryItem");
            DropIndex("dbo.ItemLocation", new[] { "LocationId" });
            DropIndex("dbo.ItemLocation", new[] { "ItemId" });
            DropTable("dbo.ItemLocation");
            CreateIndex("dbo.LocationInventoryItem", "InventoryItem_ItemID");
            CreateIndex("dbo.LocationInventoryItem", "Location_LocID");
            AddForeignKey("dbo.LocationInventoryItem", "InventoryItem_ItemID", "dbo.InventoryItem", "ItemID", cascadeDelete: true);
            AddForeignKey("dbo.LocationInventoryItem", "Location_LocID", "dbo.Location", "LocID", cascadeDelete: true);
        }
    }
}
