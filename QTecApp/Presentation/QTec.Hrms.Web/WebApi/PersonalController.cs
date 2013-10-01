using System;
using System.Linq;
using System.Web.Http;

namespace QTec.Hrms.Web.WebApi
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using QTec.Hrms.Business.Contracts;
    using QTec.Hrms.Models;

    public class PersonalController : ApiController
    {
        /// <summary>
        /// The employee manager.
        /// </summary>
        private readonly IEmployeeManager employeeManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalController" /> class.
        /// </summary>
        /// <param name="employeeManager">The employee manager.</param>
        public PersonalController(IEmployeeManager employeeManager)
        {
            this.employeeManager = employeeManager;
        }

        [HttpGet]
        [Queryable]
        public IQueryable<Employee> Employees()
        {
            var query = this.employeeManager.GetEmployees();
            var totalRecords = query.Count();
            HttpContext.Current.Response.Headers.Add("X-InlineCount", totalRecords.ToString());
            return query;
        }
 
        [HttpGet]
        public Employee EmployeeById(int id)
        {
            return this.employeeManager.GetEmployeeById(id);
        }

        /// <summary>
        /// The is email unique.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="HttpResponseMessage"/>.
        /// </returns>
        [HttpGet]
        public HttpResponseMessage IsEmailUnique(string email)
        {
            try
            {
                var isEmailUnique = this.employeeManager.IsEmailUnique(email);
                return this.Request.CreateResponse(HttpStatusCode.OK, isEmailUnique);
            }
            catch (Exception exception)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exception);
            }
        }

        [HttpGet]
        public List<Designation> Designations()
        {
            return this.employeeManager.GetDesignations();
        }

        /// <summary>
        /// Posts the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PostEmployee([FromBody] Employee employee)
        {
            try
            {
                this.employeeManager.AddEmployee(employee);
                var response = Request.CreateResponse<Employee>(HttpStatusCode.Created, employee);
                string uri = Url.Link("DefaultApi", new { id = employee.EmployeeId });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception exp)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exp.Message);
            }
        }

        [HttpPut]
        public HttpResponseMessage PutEmployee(int id, [FromBody]Employee employee)
        {
           
            try
            {
                this.employeeManager.UpdateEmployee(employee);
                return Request.CreateResponse<Employee>(HttpStatusCode.Accepted, employee);
            }
            catch (Exception exp)
            {
                return Request.CreateResponse(HttpStatusCode.NotModified, exp.Message);
            }
        }
    }
}