namespace QTec.Hrms.DataTier.Repositories
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using QTec.Hrms.DataTier.Contracts;
    using QTec.Hrms.Models;
    using QTec.Hrms.Models.Dto;

    /// <summary>
    /// Employee Repository
    /// </summary>
    public class EmployeeRepository : EFRepository<Employee>, IEmployeeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository" /> class.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        public EmployeeRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Determines whether the specified email id exists or not.
        /// </summary>
        /// <param name="emailId">The email id.</param>
        /// <returns>true if exists else returns false</returns>
        public bool IsEmailDuplicate(string emailId)
        {
            return this.DbContext.Set<Employee>().Any(e => e.Email.Equals(emailId));
        }

        /// <summary>
        /// Gets the employees with designation.
        /// </summary>
        /// <returns>IQueryable of Employees</returns>
        public IQueryable<Employee> GetEmployeesWithDesignation()
        {
            //var zero = 0;
            //var result = 1 / zero;
            return this.DbContext.Set<Employee>().Include("Designation");
        }

        /// <summary>
        /// The get employee personal info.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="EmployeePersonalInfo"/>.
        /// </returns>
        public EmployeePersonalInfo GetEmployeePersonalInfo(int id)
        {
            return this.DbContext.Set<Employee>()
                .Select(
                    emp =>
                    new EmployeePersonalInfo
                        {
                            EmployeeId = emp.EmployeeId,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            Email = emp.Email,
                            DesignationId = emp.DesignationId,
                            DateOfBirth = emp.DateOfBirth,
                            Gender = emp.Gender,
                            Salary = emp.Salary
                        })
                .FirstOrDefault(e => e.EmployeeId.Equals(id));
        }

       public IList<EmployeeLanguages> GetEmployeeLanguages(int id)
       {
           return this.DbContext.Set<EmployeeLanguages>().Include("Language").Where(e => e.EmployeeId.Equals(id)).ToList();
       }
    }
}
