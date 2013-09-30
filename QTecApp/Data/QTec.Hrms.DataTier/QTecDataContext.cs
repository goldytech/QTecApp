namespace QTec.Hrms.DataTier
{
    using System.Data.Entity;
    using QTec.Hrms.Models;

    /// <summary>
    /// The QTEC data context.
    /// </summary>
    public class QTecDataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QTecDataContext"/> class.
        /// </summary>
        public QTecDataContext()
            : base(nameOrConnectionString: "QTec")
        {
            Database.SetInitializer(new QTecDbInitializer());
        }

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        public DbSet<Employee> Employees
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the designations.
        /// </summary>
        public DbSet<Designation> Designations
        {
            get;
            set;
        }
    }
}