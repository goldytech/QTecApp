using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QTec.Hrms.Web.App_Start
{
    using Microsoft.Practices.ServiceLocation;

    using Ninject;

    /// <summary>
    /// The Ninject service locator.
    /// </summary>
    public class NinjectServiceLocator : ServiceLocatorImplBase
    {
        public NinjectServiceLocator(IKernel kernel)
        {
            this.Kernel = kernel;
        }

        /// <summary>
        /// Gets the kernel.
        /// </summary>
        public IKernel Kernel { get; private set; }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return key == null ? this.Kernel.Get(serviceType) : this.Kernel.Get(serviceType, key);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return this.Kernel.GetAll(serviceType);
        }
    }
}