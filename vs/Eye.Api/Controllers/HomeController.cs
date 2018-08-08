using Eye.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Eye.Api.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Test()
        {
            return Json(new { Result = "sucess" }, JsonRequestBehavior.AllowGet);
        }
    }
}
