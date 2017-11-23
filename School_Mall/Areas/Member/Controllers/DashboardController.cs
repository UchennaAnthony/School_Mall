using School_Mall.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Mall.Areas.Member.Controllers
{
    public class DashboardController : BaseController
    {
        // GET: Member/Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}