namespace MedicalInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingDoctor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "DoctorType_Id", "dbo.DoctorTypes");
            DropIndex("dbo.Doctors", new[] { "DoctorType_Id" });
            DropColumn("dbo.Doctors", "DoctorTypeId");
            RenameColumn(table: "dbo.Doctors", name: "DoctorType_Id", newName: "DoctorTypeId");
            AlterColumn("dbo.Doctors", "DoctorTypeId", c => c.Short(nullable: false));
            AlterColumn("dbo.Doctors", "DoctorTypeId", c => c.Short(nullable: false));
            CreateIndex("dbo.Doctors", "DoctorTypeId");
            AddForeignKey("dbo.Doctors", "DoctorTypeId", "dbo.DoctorTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "DoctorTypeId", "dbo.DoctorTypes");
            DropIndex("dbo.Doctors", new[] { "DoctorTypeId" });
            AlterColumn("dbo.Doctors", "DoctorTypeId", c => c.Short());
            AlterColumn("dbo.Doctors", "DoctorTypeId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Doctors", name: "DoctorTypeId", newName: "DoctorType_Id");
            AddColumn("dbo.Doctors", "DoctorTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctors", "DoctorType_Id");
            AddForeignKey("dbo.Doctors", "DoctorType_Id", "dbo.DoctorTypes", "Id");
        }
    }
}
