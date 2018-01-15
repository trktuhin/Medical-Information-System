namespace MedicalInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPropToHospital : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hospitals", "IsApproved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hospitals", "IsApproved");
        }
    }
}
