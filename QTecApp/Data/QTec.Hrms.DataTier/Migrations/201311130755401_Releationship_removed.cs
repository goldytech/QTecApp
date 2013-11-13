namespace QTec.Hrms.DataTier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Releationship_removed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Languages", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Languages", new[] { "Employee_EmployeeId" });
            DropColumn("dbo.Languages", "Employee_EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Languages", "Employee_EmployeeId", c => c.Int());
            CreateIndex("dbo.Languages", "Employee_EmployeeId");
            AddForeignKey("dbo.Languages", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
        }
    }
}
