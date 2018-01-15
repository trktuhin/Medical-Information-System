namespace MedicalInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDoctorAndDoctorType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 300),
                        Area = c.String(nullable: false, maxLength: 100),
                        HospitalName = c.String(maxLength: 50),
                        DoctorTypeId = c.Int(nullable: false),
                        WorkHour = c.String(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        DoctorType_Id = c.Short(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoctorTypes", t => t.DoctorType_Id)
                .Index(t => t.DoctorType_Id);
            
            CreateTable(
                "dbo.DoctorTypes",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                        Fee = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "DoctorType_Id", "dbo.DoctorTypes");
            DropIndex("dbo.Doctors", new[] { "DoctorType_Id" });
            DropTable("dbo.DoctorTypes");
            DropTable("dbo.Doctors");
        }
    }
}
