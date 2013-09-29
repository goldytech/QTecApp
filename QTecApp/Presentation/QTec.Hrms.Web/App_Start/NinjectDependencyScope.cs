namespace QTec.Hrms.Web.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Web.Http.Dependencies;

    using Ninject;
    using Ninject.Syntax;

    public class NinjectDependencyScope : IDependencyScope
    {
        /// <summary>
        /// The resolution root.
        /// </summary>
        private IResolutionRoot resolutionRoot;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectDependencyScope"/> class.
        /// </summary>
        /// <param name="resolutionRoot">
        /// The resolution root.
        /// </param>
        internal NinjectDependencyScope(IResolutionRoot resolutionRoot)
        {
            Contract.Assert(resolutionRoot != null);
            this.resolutionRoot = resolutionRoot;
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            var disposable = this.resolutionRoot as IDisposable;
            if (disposable == null)
            {
                return;
            }
            disposable.Dispose();
            this.resolutionRoot = null;
        }

        /// <summary>
        /// The get service.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// resolver of NINJECT is null
        /// </exception>
        public object GetService(Type serviceType)
        {
            if (this.resolutionRoot == null)
            {
               throw new Exception("The resolver of Ioc is null"); 
            }

            return this.resolutionRoot.TryGet(serviceType);
        }

        /// <summary>
        /// The get services.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (this.resolutionRoot == null)
            {
                throw new Exception("The resolver of Ioc is null");
            }

            return resolutionRoot.GetAll(serviceType);
        }
    }
}