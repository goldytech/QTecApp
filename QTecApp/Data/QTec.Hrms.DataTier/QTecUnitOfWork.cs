  
namespace QTec.Hrms.DataTier
{
    using System;
    using QTec.Hrms.DataTier.Contracts;
    using QTec.Hrms.Models;

    /// <summary>
    /// The QTEC unit of work.
    /// </summary>
    public class QTecUnitOfWork : IQTecUnitOfWork, IDisposable
    {
       

        /// <summary>
        /// Initializes a new instance of the <see cref="QTecUnitOfWork" /> class.
        /// </summary>
        /// <param name="repositoryProvider">The repository provider.</param>
        public QTecUnitOfWork(IRepositoryProvider repositoryProvider)
        {
            this.DbContext = new QTecDataContext();
            this.RepositoryProvider = repositoryProvider;
            this.RepositoryProvider.DbContext = this.DbContext;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.DbContext != null)
                {
                    this.DbContext.Dispose();
                }
            }
        }

        /// <summary>
        /// Gets the employee repository.
        /// </summary>
        /// <value>The employee repository.</value>
        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                return this.GetRepo<IEmployeeRepository>();
            }
        }

        /// <summary>
        /// Gets the designation repository.
        /// </summary>
        /// <value>The designation repository.</value>
        public IRepository<Designation> DesignationRepository
        {
            get
            {
                return this.GetStandardRepo<Designation>();
            }
        }

        /// <summary>
        /// Commits the changes in database.
        /// </summary>
        public void Commit()
        {
            this.DbContext.SaveChanges();
        }

        protected IRepositoryProvider RepositoryProvider
        {
            get;
            set;
        }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        private QTecDataContext DbContext
        {
            get;
            set;
        }
    }
}