namespace MedicalInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingPropToAmbulance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ambulances", "IsApproved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ambulances", "IsApproved");
        }
    }
}
