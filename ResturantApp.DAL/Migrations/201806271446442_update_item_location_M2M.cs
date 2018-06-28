namespace ResturantApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_item_location_M2M : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InventoryItem", "LocationId", "dbo.Location");
            DropIndex("dbo.InventoryItem", new[] { "LocationId" });
            CreateTable(
                "dbo.LocationInventoryItem",
                c => new
                    {
                        Location_LocID = c.Int(nullable: false),
                        InventoryItem_ItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Location_LocID, t.InventoryItem_ItemID })
                .ForeignKey("dbo.Location", t => t.Location_LocID, cascadeDelete: true)
                .ForeignKey("dbo.InventoryItem", t => t.InventoryItem_ItemID, cascadeDelete: true)
                .Index(t => t.Location_LocID)
                .Index(t => t.InventoryItem_ItemID);
            
            DropColumn("dbo.InventoryItem", "LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InventoryItem", "LocationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.LocationInventoryItem", "InventoryItem_ItemID", "dbo.InventoryItem");
            DropForeignKey("dbo.LocationInventoryItem", "Location_LocID", "dbo.Location");
            DropIndex("dbo.LocationInventoryItem", new[] { "InventoryItem_ItemID" });
            DropIndex("dbo.LocationInventoryItem", new[] { "Location_LocID" });
            DropTable("dbo.LocationInventoryItem");
            CreateIndex("dbo.InventoryItem", "LocationId");
            AddForeignKey("dbo.InventoryItem", "LocationId", "dbo.Location", "LocID", cascadeDelete: true);
        }
    }
}
