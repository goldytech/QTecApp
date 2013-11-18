namespace QTec.Hrms.Business.Personal
{
    using System.Collections.Generic;
    using System.Linq;
    using QTec.Hrms.Business.Aspects;
    using QTec.Hrms.Business.Contracts;
    using QTec.Hrms.Business.CustomExceptions;
    using QTec.Hrms.DataTier.Contracts;
    using QTec.Hrms.Models;
    using QTec.Hrms.Models.Dto;

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
        [DefensiveProgrammingAspect]
        [ExceptionAspect]
        public EmployeeManager(IQTecUnitOfWork qTecUnitOfWork)
        {
            //if (qTecUnitOfWork == null)
            //{
            //    throw new ArgumentNullException("qTecUnitOfWork");
            //}
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
        [ExceptionAspect]
        public Employee GetEmployeeById(int id)
        {
            if (id == 0 || id < 0)
            {
                throw new InvalidEmployeeIdException("No such employee exists");
            }

            //var zero = 0;
            //var result = 1 / zero;
            Employee emp = this.qTecUnitOfWork.EmployeeRepository.GetById(id);
            return emp;
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
        [ExceptionAspect]
        public IQueryable<Employee> GetEmployees()
        {
            return this.qTecUnitOfWork.EmployeeRepository.GetEmployeesWithDesignation();
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
        [ExceptionAspect]
        public EmployeePersonalInfo GetEmployeePersonalInfo(int id)
        {
            return this.qTecUnitOfWork.EmployeeRepository.GetEmployeePersonalInfo(id);
        }

        /// <summary>
        /// The get employee languages.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public IList<EmployeeLanguageInfo> GetEmployeeLanguages(int id)
        {
            return this.qTecUnitOfWork.EmployeeRepository.GetEmployeeLanguages(id).Select(
                empLang => new EmployeeLanguageInfo
                        {
                            EmployeeId = empLang.EmployeeId,
                            Fluency = empLang.Fluency,
                            LanguageId = empLang.LanguageId,
                            LanguageName = empLang.Language.Name }).ToList();
        }

        /// <summary>
        /// The save employee.
        /// </summary>
        /// <param name="employeeId">The employee id.</param>
        /// <param name="personalInfo">The personal info.</param>
        /// <param name="languageInfo">The language info.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public bool SaveEmployee(int employeeId, EmployeePersonalInfo personalInfo, List<EmployeeLanguageInfo> languageInfo)
        {
            if (employeeId > 0) // update employee
            {
                var employeetobeUpdated = this.qTecUnitOfWork.EmployeeRepository.GetById(employeeId);

                if (employeetobeUpdated != null)
                {
                    employeetobeUpdated.FirstName = personalInfo.FirstName;
                    employeetobeUpdated.LastName = personalInfo.LastName;
                    employeetobeUpdated.EmployeeId = employeeId;
                    employeetobeUpdated.Email = personalInfo.Email;
                    employeetobeUpdated.DesignationId = personalInfo.DesignationId;

                }

                foreach (var employeeLanguageInfo in languageInfo)
                {
                    if (employeetobeUpdated == null)
                    {
                        continue;
                    }

                    var languageTobeUpdated = employeetobeUpdated.Languages.FirstOrDefault(lang => lang.LanguageId.Equals(employeeLanguageInfo.LanguageId) && lang.EmployeeId.Equals(employeeId));

                    if (languageTobeUpdated != null)
                    {
                        languageTobeUpdated.Fluency = employeeLanguageInfo.Fluency;
                    }
                    else
                    {
                        //// the language is not found in the current languages collection that is associated with the employee so add a new
                        employeetobeUpdated.Languages.Add(
                            new EmployeeLanguages
                                {
                                    EmployeeId = employeeLanguageInfo.EmployeeId,
                                    Fluency = employeeLanguageInfo.Fluency,
                                    LanguageId = employeeLanguageInfo.LanguageId
                                });
                    }

                }

                this.qTecUnitOfWork.EmployeeRepository.Update(employeetobeUpdated);
                this.qTecUnitOfWork.Commit();
            }
        }
    }
}