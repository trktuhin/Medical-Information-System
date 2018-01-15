namespace MedicalInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingBloodBank : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodBanks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false),
                        Area = c.String(nullable: false, maxLength: 30),
                        Address = c.String(nullable: false, maxLength: 100),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BloodBanks");
        }
    }
}
