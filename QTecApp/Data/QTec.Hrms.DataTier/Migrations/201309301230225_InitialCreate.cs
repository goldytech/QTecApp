namespace QTec.Hrms.DataTier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DesignationId = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Salary = c.Double(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Designations");
        }
    }
}
