namespace ResturantApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbUpdateOne : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Group", "Tax1", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Group", "Tax2", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Group", "Tax3", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Category", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Category", "Name", c => c.String());
            AlterColumn("dbo.Group", "Tax3", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Group", "Tax2", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Group", "Tax1", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
