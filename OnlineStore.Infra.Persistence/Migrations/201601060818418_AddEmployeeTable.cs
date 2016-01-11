namespace OnlineStore.Infra.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        HiredDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            AddColumn("dbo.Customer", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "City");
            DropTable("dbo.Employee");
        }
    }
}
