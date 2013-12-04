namespace QTec.Hrms.Web.App_Start
{
    using System.Web.Http.Dependencies;

    using Ninject;

    /// <summary>
    /// The ninject dependency resolver.
    /// </summary>
    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        /// <summary>
        /// The kernel.
        /// </summary>
        private readonly IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectDependencyResolver"/> class.
        /// </summary>
        /// <param name="kernel">
        /// The kernel.
        /// </param>
        internal NinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        /// <summary>
        /// The begin scope.
        /// </summary>
        /// <returns>
        /// The <see cref="IDependencyScope"/>.
        /// </returns>
        public IDependencyScope BeginScope()
        {
          return new NinjectDependencyScope(this.kernel.BeginBlock());
        }
    }
}