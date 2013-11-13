namespace QTec.Hrms.DataTier.Contracts
{
    using System.Linq;

    using QTec.Hrms.Models;
    using QTec.Hrms.Models.Dto;

    /// <summary>
    /// The EmployeeRepository interface.
    /// </summary>
    public interface IEmployeeRepository : IRepository<Employee>
    {
        /// <summary>
        /// Determines whether the specified email id exists or not.
        /// </summary>
        /// <param name="emailId">The email id.</param>
        /// <returns>true if exists else returns false</returns>
        bool IsEmailDuplicate(string emailId);

        IQueryable<Employee> GetEmployeesWithDesignation();

        /// <summary>
        /// The get employee personal info.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="EmployeePersonalInfo"/>.
        /// </returns>
        EmployeePersonalInfo GetEmployeePersonalInfo(int id);
    }
}