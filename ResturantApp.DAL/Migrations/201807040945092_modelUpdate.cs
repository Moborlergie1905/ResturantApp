namespace ResturantApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AdjustmentItem", "Unit", c => c.Int(nullable: false));
            AlterColumn("dbo.PurchaseItem", "Unit", c => c.Int(nullable: false));
            AlterColumn("dbo.DeliveryItem", "Unit", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductionIngredient", "Unit", c => c.Int(nullable: false));
            AlterColumn("dbo.PurchaseOrderItem", "Unit", c => c.Int(nullable: false));
            AlterColumn("dbo.SalesInvoiceItem", "Unit", c => c.Int(nullable: false));
            AlterColumn("dbo.TransferItem", "Unit", c => c.Int(nullable: false));
            AlterColumn("dbo.WastageItem", "Unit", c => c.Int(nullable: false));
            CreateIndex("dbo.AdjustmentItem", "Unit");
            CreateIndex("dbo.PurchaseItem", "Unit");
            CreateIndex("dbo.DeliveryItem", "Unit");
            CreateIndex("dbo.ProductionIngredient", "Unit");
            CreateIndex("dbo.PurchaseOrderItem", "Unit");
            CreateIndex("dbo.SalesInvoiceItem", "Unit");
            CreateIndex("dbo.TransferItem", "Unit");
            CreateIndex("dbo.WastageItem", "Unit");
            AddForeignKey("dbo.PurchaseItem", "Unit", "dbo.MeasurementUnit", "UnitID");
            AddForeignKey("dbo.AdjustmentItem", "Unit", "dbo.MeasurementUnit", "UnitID");
            AddForeignKey("dbo.DeliveryItem", "Unit", "dbo.MeasurementUnit", "UnitID");
            AddForeignKey("dbo.ProductionIngredient", "Unit", "dbo.MeasurementUnit", "UnitID");
            AddForeignKey("dbo.PurchaseOrderItem", "Unit", "dbo.MeasurementUnit", "UnitID");
            AddForeignKey("dbo.SalesInvoiceItem", "Unit", "dbo.MeasurementUnit", "UnitID");
            AddForeignKey("dbo.TransferItem", "Unit", "dbo.MeasurementUnit", "UnitID");
            AddForeignKey("dbo.WastageItem", "Unit", "dbo.MeasurementUnit", "UnitID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WastageItem", "Unit", "dbo.MeasurementUnit");
            DropForeignKey("dbo.TransferItem", "Unit", "dbo.MeasurementUnit");
            DropForeignKey("dbo.SalesInvoiceItem", "Unit", "dbo.MeasurementUnit");
            DropForeignKey("dbo.PurchaseOrderItem", "Unit", "dbo.MeasurementUnit");
            DropForeignKey("dbo.ProductionIngredient", "Unit", "dbo.MeasurementUnit");
            DropForeignKey("dbo.DeliveryItem", "Unit", "dbo.MeasurementUnit");
            DropForeignKey("dbo.AdjustmentItem", "Unit", "dbo.MeasurementUnit");
            DropForeignKey("dbo.PurchaseItem", "Unit", "dbo.MeasurementUnit");
            DropIndex("dbo.WastageItem", new[] { "Unit" });
            DropIndex("dbo.TransferItem", new[] { "Unit" });
            DropIndex("dbo.SalesInvoiceItem", new[] { "Unit" });
            DropIndex("dbo.PurchaseOrderItem", new[] { "Unit" });
            DropIndex("dbo.ProductionIngredient", new[] { "Unit" });
            DropIndex("dbo.DeliveryItem", new[] { "Unit" });
            DropIndex("dbo.PurchaseItem", new[] { "Unit" });
            DropIndex("dbo.AdjustmentItem", new[] { "Unit" });
            AlterColumn("dbo.WastageItem", "Unit", c => c.String());
            AlterColumn("dbo.TransferItem", "Unit", c => c.String());
            AlterColumn("dbo.SalesInvoiceItem", "Unit", c => c.String());
            AlterColumn("dbo.PurchaseOrderItem", "Unit", c => c.String());
            AlterColumn("dbo.ProductionIngredient", "Unit", c => c.String());
            AlterColumn("dbo.DeliveryItem", "Unit", c => c.String());
            AlterColumn("dbo.PurchaseItem", "Unit", c => c.String());
            AlterColumn("dbo.AdjustmentItem", "Unit", c => c.String());
        }
    }
}
