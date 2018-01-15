namespace MedicalInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingConstraintToDoctorAndAdingHospital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false, maxLength: 200),
                        WorkDays = c.String(nullable: false, maxLength: 50),
                        Area = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Doctors", "WorkHour", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doctors", "WorkHour", c => c.String(nullable: false));
            DropTable("dbo.Hospitals");
        }
    }
}
