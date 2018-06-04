namespace ResturantApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Mobile", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "Address", c => c.String());
            AlterColumn("dbo.Customer", "Mobile", c => c.String());
            AlterColumn("dbo.Customer", "LastName", c => c.String());
            AlterColumn("dbo.Customer", "FirstName", c => c.String());
        }
    }
}
