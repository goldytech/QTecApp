namespace QTec.Hrms.Business.Personal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using QTec.Hrms.Business.Contracts;
    using QTec.Hrms.DataTier.Contracts;
    using QTec.Hrms.Models;

    /// <summary>
    /// The employee manager.
    /// </summary>
    public class EmployeeManager : IEmployeeManager
    {
        #region Declarations
        /// <summary>
        /// The data repositories unit of work.
        /// </summary>
        private readonly IQTecUnitOfWork qTecUnitOfWork; 
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeManager" /> class.
        /// </summary>
        /// <param name="qTecUnitOfWork">The QTec unit of work.</param>
        public EmployeeManager(IQTecUnitOfWork qTecUnitOfWork)
        {
            this.qTecUnitOfWork = qTecUnitOfWork;
        } 
        #endregion

        /// <summary>
        /// Gets the designations.
        /// </summary>
        /// <returns>List of Designation</returns>
        public List<Designation> GetDesignations()
        {
            return this.qTecUnitOfWork.DesignationRepository.GetAll().ToList();
        }

        /// <summary>
        /// Determines whether  email is unique
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>true if exists else return false</returns>
        public bool IsEmailUnique(string email)
        {
            return this.qTecUnitOfWork.EmployeeRepository.IsEmailDuplicate(email);
        }

        /// <summary>
        /// Gets the employee by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Employee</returns>
        public Employee GetEmployeeById(int id)
        {
            return this.qTecUnitOfWork.EmployeeRepository.GetById(id);
        }

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public void AddEmployee(Employee employee)
        {
            this.qTecUnitOfWork.EmployeeRepository.Add(employee);
            this.qTecUnitOfWork.Commit();
        }

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public void UpdateEmployee(Employee employee)
        {
            this.qTecUnitOfWork.EmployeeRepository.Update(employee);
            this.qTecUnitOfWork.Commit();
        }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns>IQueryable of Employees</returns>
        
        public IQueryable<Employee> GetEmployees()
        {
            return this.qTecUnitOfWork.EmployeeRepository.GetEmployeesWithDesignation();
        }

        
    }
}
