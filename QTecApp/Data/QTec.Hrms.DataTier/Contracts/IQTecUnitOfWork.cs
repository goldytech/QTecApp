namespace QTec.Hrms.DataTier.Contracts
{
    using QTec.Hrms.Models;

    /// <summary>
    /// The interface of QTEC Unit of Work
    /// </summary>
    public interface IQTecUnitOfWork
    {
        /// <summary>
        /// Gets the employee repository.
        /// </summary>
        /// <value>The employee repository.</value>
        IEmployeeRepository EmployeeRepository
        {
            get;
        }

        /// <summary>
        /// Gets the designation repository.
        /// </summary>
        /// <value>The designation repository.</value>
        IRepository<Designation> DesignationRepository
        {
            get;
        }

        /// <summary>
        /// Gets the language repository.
        /// </summary>
        IRepository<Language> LanguageRepository
        {
            get;
        }


        IRepository<EmployeeLanguages> EmployeeLanguagesRepository { get; }
        /// <summary>
        /// Commits the changes in database.
        /// </summary>
        void Commit();
    }
}
