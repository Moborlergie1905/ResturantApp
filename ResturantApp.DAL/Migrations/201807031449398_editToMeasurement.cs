namespace ResturantApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editToMeasurement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MeasurementUnit", "Notation", c => c.String(nullable: false));
            AlterColumn("dbo.MeasurementUnit", "UnitName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MeasurementUnit", "UnitName", c => c.String());
            DropColumn("dbo.MeasurementUnit", "Notation");
        }
    }
}
