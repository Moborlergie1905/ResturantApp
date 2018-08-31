namespace ResturantApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class currencytbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CurrencyType = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Supplier", "SupplierCurrency", c => c.Int(nullable: false));
            AlterColumn("dbo.Supplier", "Grade", c => c.Int(nullable: false));
            CreateIndex("dbo.Supplier", "SupplierCurrency");
            AddForeignKey("dbo.Supplier", "SupplierCurrency", "dbo.Currency", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Supplier", "SupplierCurrency", "dbo.Currency");
            DropIndex("dbo.Supplier", new[] { "SupplierCurrency" });
            AlterColumn("dbo.Supplier", "Grade", c => c.String());
            AlterColumn("dbo.Supplier", "SupplierCurrency", c => c.String());
            AlterColumn("dbo.Product", "Name", c => c.String());
            DropTable("dbo.Currency");
        }
    }
}
