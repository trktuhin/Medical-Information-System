namespace MedicalInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AmbulanceModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ambulances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false),
                        Area = c.String(nullable: false, maxLength: 30),
                        HospitalName = c.String(nullable: false, maxLength: 100),
                        WorkHour = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ambulances");
        }
    }
}
