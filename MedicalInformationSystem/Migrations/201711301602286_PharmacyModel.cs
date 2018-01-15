namespace MedicalInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PharmacyModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pharmacies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false, maxLength: 100),
                        Area = c.String(nullable: false, maxLength: 20),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pharmacies");
        }
    }
}
