using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QTec.Hrms.Web.Controllers
{
    public class FilesController : Controller
    {
        //
        // GET: /Files/

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase fileBase)
         {
            
            return null;
        }

    }
}
