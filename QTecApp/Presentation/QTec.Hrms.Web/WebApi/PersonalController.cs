using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QTec.Hrms.Web.WebApi
{
    using System.Web;

    using QTec.Hrms.Business.Contracts;
    using QTec.Hrms.Models;

    public class PersonalController : ApiController
    {
        private readonly IEmployeeManager employeeManager;

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
    }
}
