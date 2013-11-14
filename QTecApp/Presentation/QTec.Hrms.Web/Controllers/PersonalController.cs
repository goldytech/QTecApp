using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QTec.Hrms.Web.Controllers
{
    public class PersonalController : Controller
    {
        //
        // GET: /Personal/

        public ActionResult Employees()
        {
            return this.PartialView();
        }

        public ActionResult About()
        {
            return this.PartialView();
        }

        public ActionResult EmployeeEdit()
        {
            return this.PartialView();
        }

        public ActionResult EmployeeEditNew()
        {
            return this.PartialView();
        }

    }
}
