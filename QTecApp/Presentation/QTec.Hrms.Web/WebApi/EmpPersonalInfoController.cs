 namespace QTec.Hrms.Web.WebApi
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using QTec.Hrms.Business.Contracts;

    /// <summary>
    /// The emp personal info controller.
    /// </summary>
    public class EmpPersonalInfoController : ApiController
    {
        /// <summary>
        /// The employee manager.
        /// </summary>
        private readonly IEmployeeManager employeeManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmpPersonalInfoController"/> class.
        /// </summary>
        /// <param name="employeeManager">
        /// The employee manager.
        /// </param>
        public EmpPersonalInfoController(IEmployeeManager employeeManager)
        {
            this.employeeManager = employeeManager;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="HttpResponseMessage"/>.
        /// </returns>
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var empPersonalInfo = this.employeeManager.GetEmployeePersonalInfo(id);
                return empPersonalInfo == null ? this.Request.CreateResponse(HttpStatusCode.NotFound) : this.Request.CreateResponse(HttpStatusCode.OK, empPersonalInfo);
            }
            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        
    }
}
