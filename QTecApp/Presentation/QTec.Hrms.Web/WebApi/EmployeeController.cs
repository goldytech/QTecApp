namespace QTec.Hrms.Web.WebApi
{
    using System.Web.Http;

    using QTec.Hrms.Business.Contracts;
    using QTec.Hrms.Models.Dto;
    using QTec.Hrms.Web.ActionFilters;

    [RoutePrefix("api")]
    public class EmployeeController : ApiController
    {
        /// <summary>
        /// The employee manager.
        /// </summary>
        private readonly IEmployeeManager employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            this.employeeManager = employeeManager;
        }

        /// <summary>
        /// The get employee personal info.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [Route("employees/{id:int}/personal")]
        [Cache(CacheExpiryDuration =30)]
        [ETag]
        public IHttpActionResult GetEmployeePersonalInfo(int id)
        {
            var empPersonalInfo = this.employeeManager.GetEmployeePersonalInfo(id);

            if (empPersonalInfo == null)
            {
                return this.NotFound();
            }

            return this.Ok(empPersonalInfo);
        }

        /// <summary>
        /// The get employee languages.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [Route("employees/{id:int}/languages")]
        [HttpGet]
        //[Cache(CacheExpiryDuration = 60)]
        //[ETag]
        public IHttpActionResult GetEmployeeLanguages(int id)
        {
            var languages = this.employeeManager.GetEmployeeLanguages(id);
           
            if (languages == null)
            {
                return this.NotFound();
            }

            return this.Ok(languages);
        }

        /// <summary>
        /// The save employee.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="employeeInfo">
        /// The employee info.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpPut]
        [Route("employees/{id:int}")]
        [ETag]
        public IHttpActionResult SaveEmployee(int id, [FromBody] EmployeeInfo employeeInfo)
        {
            this.employeeManager.SaveEmployee(id, employeeInfo.EmployeePersonalInfo, employeeInfo.EmployeeLanguages);
            return this.Ok();
        }
    }
}
