namespace ResturantApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStockHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockHistory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InventoryItem", t => t.ItemId)
                .Index(t => t.ItemId);
            
            AlterColumn("dbo.InventoryItem", "IsExpiry", c => c.Boolean(nullable: false));
            AlterColumn("dbo.InventoryItem", "HideInReport", c => c.Boolean(nullable: false));
            AlterColumn("dbo.InventoryItem", "Disconitued", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockHistory", "ItemId", "dbo.InventoryItem");
            DropIndex("dbo.StockHistory", new[] { "ItemId" });
            AlterColumn("dbo.InventoryItem", "Disconitued", c => c.Byte(nullable: false));
            AlterColumn("dbo.InventoryItem", "HideInReport", c => c.Byte(nullable: false));
            AlterColumn("dbo.InventoryItem", "IsExpiry", c => c.Byte(nullable: false));
            DropTable("dbo.StockHistory");
        }
    }
}
