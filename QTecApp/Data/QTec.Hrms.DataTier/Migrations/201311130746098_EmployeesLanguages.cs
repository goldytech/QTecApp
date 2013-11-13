namespace QTec.Hrms.DataTier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeesLanguages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Employee_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.LanguageId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .Index(t => t.Employee_EmployeeId);
            
            CreateTable(
                "dbo.EmployeeLanguages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        Fluency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.LanguageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeLanguages", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.EmployeeLanguages", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Languages", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeLanguages", new[] { "LanguageId" });
            DropIndex("dbo.EmployeeLanguages", new[] { "EmployeeId" });
            DropIndex("dbo.Languages", new[] { "Employee_EmployeeId" });
            DropTable("dbo.EmployeeLanguages");
            DropTable("dbo.Languages");
        }
    }
}
