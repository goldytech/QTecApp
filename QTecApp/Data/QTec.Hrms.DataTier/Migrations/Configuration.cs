namespace QTec.Hrms.DataTier.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using QTec.Hrms.Models;

    public class Configuration : DbMigrationsConfiguration<QTec.Hrms.DataTier.QTecDataContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.ContextKey = "QTec.Hrms.DataTier.QTecDataContext";
        }

        /// <summary>
        /// The seed.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Seed(QTecDataContext context)
        {
            AddDesignations(context);
            AddEmployees(context);
            context.SaveChanges();

            base.Seed(context);
        }

        /// <summary>
        /// The add designations.
        /// </summary>
        /// <param name="dataContext">
        /// The data context.
        /// </param>
        private static void AddDesignations(QTecDataContext dataContext)
        {
            dataContext.Designations.AddOrUpdate(new Designation { Id = 1, Name = "Software Engineer" });
            dataContext.Designations.AddOrUpdate(new Designation { Id = 2, Name = "Sr. Software Engineer" });
            dataContext.Designations.AddOrUpdate(new Designation { Id = 3, Name = "Software Trainee" });
            dataContext.Designations.AddOrUpdate(new Designation { Id = 4, Name = "Team Lead" });
            dataContext.Designations.AddOrUpdate(new Designation { Id = 5, Name = "Tech Lead" });
            dataContext.Designations.AddOrUpdate(new Designation { Id = 6, Name = "QA Engineer" });

        }

        /// <summary>
        /// The add employees.
        /// </summary>
        /// <param name="dataContext">
        /// The data context.
        /// </param>
        private static void AddEmployees(QTecDataContext dataContext)
        {
            dataContext.Employees.AddOrUpdate(
                new Employee
                {
                    EmployeeId = 1,
                    DesignationId = 1,
                    Email = "shahrukh@gmail.com",
                    FirstName = "Shahrukh",
                    LastName = "Khan",
                    Gender = "male",
                    DateOfBirth = new DateTime(1976, 11, 1),
                    Salary = 12484
                });
            dataContext.Employees.AddOrUpdate(
                new Employee
                {
                    EmployeeId = 2,
                    DesignationId = 2,
                    Email = "salman@gmail.com",
                    FirstName = "Salman",
                    LastName = "Khan",
                    Gender = "male",
                    DateOfBirth = new DateTime(1986, 11, 21),
                    Salary = 48473
                });

            dataContext.Employees.AddOrUpdate(
                new Employee
                {
                    EmployeeId = 3,
                    DesignationId = 4,
                    Email = "aamir@gmail.com",
                    FirstName = "Aamir",
                    LastName = "Khan",
                    Gender = "male",
                    DateOfBirth = new DateTime(1977, 10, 8),
                    Salary = 36252
                });

            dataContext.Employees.AddOrUpdate(
                new Employee
                {
                    EmployeeId = 4,
                    DesignationId = 3,
                    Email = "saif@gmail.com",
                    FirstName = "Saif Ali",
                    LastName = "Khan",
                    Gender = "male",
                    DateOfBirth = new DateTime(1973, 1, 1),
                    Salary = 37262
                });
            dataContext.Employees.AddOrUpdate(
                new Employee
                {
                    EmployeeId = 5,
                    DesignationId = 6,
                    Email = "amitabh@gmail.com",
                    FirstName = "Amitabh",
                    LastName = "Bachhan",
                    Gender = "male",
                    DateOfBirth = new DateTime(1967, 12, 21),
                    Salary = 47887
                });
            dataContext.Employees.AddOrUpdate(
                new Employee
                {
                    EmployeeId = 6,
                    DesignationId = 5,
                    Email = "anil@gmail.com",
                    FirstName = "Anil",
                    LastName = "Kapoor",
                    Gender = "male",
                    DateOfBirth = new DateTime(1978, 11, 11),
                    Salary = 23837
                });

            dataContext.Employees.AddOrUpdate(
                new Employee
                {
                    EmployeeId = 7,
                    DesignationId = 3,
                    Email = "deepika@gmail.com",
                    FirstName = "Deepika",
                    LastName = "Padukone",
                    Gender = "female",
                    DateOfBirth = new DateTime(1986, 7, 9),
                    Salary = 12484
                });

            dataContext.Employees.AddOrUpdate(
                new Employee
                {
                    EmployeeId = 8,
                    DesignationId = 4,
                    Email = "priyanka@gmail.com",
                    FirstName = "Priyanka",
                    LastName = "Chopra",
                    Gender = "female",
                    DateOfBirth = new DateTime(1996, 3, 21),
                    Salary = 83737
                });

            dataContext.Employees.AddOrUpdate(
                new Employee
                {
                    EmployeeId = 9,
                    DesignationId = 6,
                    Email = "shilpa@gmail.com",
                    FirstName = "Shilpa",
                    LastName = "Shetty",
                    Gender = "female",
                    DateOfBirth = new DateTime(1975, 2, 21),
                    Salary = 52484
                });

            dataContext.Employees.AddOrUpdate(
                new Employee
                {
                    EmployeeId = 10,
                    DesignationId = 4,
                    Email = "john@gmail.com",
                    FirstName = "Johh",
                    LastName = "Abraham",
                    Gender = "male",
                    DateOfBirth = new DateTime(1976, 12, 31),
                    Salary = 45642
                });
        }
    }
}
