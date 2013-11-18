namespace QTec.Hrms.Business.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using QTec.Hrms.Models;
    using QTec.Hrms.Models.Dto;

    public interface IEmployeeManager
    {
        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        void AddEmployee(Employee employee);

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        void UpdateEmployee(Employee employee);

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns>IQueryable of Employees</returns>
        IQueryable<Employee> GetEmployees();

        /// <summary>
        /// Gets the employee by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Employee</returns>
        Employee GetEmployeeById(int id);

        /// <summary>
        /// Determines whether  email is unique
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>true if exists else return false</returns>
        bool IsEmailUnique(string email);

        /// <summary>
        /// Gets the designations.
        /// </summary>
        /// <returns>List of Designation</returns>
        List<Designation> GetDesignations();

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

        /// <summary>
        /// The get employee languages.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<EmployeeLanguageInfo> GetEmployeeLanguages(int id);

        /// <summary>
        /// The save employee.
        /// </summary>
        /// <param name="employeeId">
        /// The employee id.
        /// </param>
        /// <param name="personalInfo">
        /// The personal info.
        /// </param>
        /// <param name="languageInfo">
        /// The language info.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool SaveEmployee(int employeeId, EmployeePersonalInfo personalInfo, List<EmployeeLanguageInfo> languageInfo);
    }
}
