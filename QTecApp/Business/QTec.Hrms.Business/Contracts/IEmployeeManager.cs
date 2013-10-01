namespace QTec.Hrms.Business.Contracts
{
    using System.Collections.Generic;
    using System.Linq;

    using QTec.Hrms.Models;

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
    }
}
