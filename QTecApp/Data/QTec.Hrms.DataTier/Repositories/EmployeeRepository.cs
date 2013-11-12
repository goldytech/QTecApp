namespace QTec.Hrms.DataTier.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    using QTec.Hrms.DataTier.Contracts;
    using QTec.Hrms.Models;

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
    }
}
