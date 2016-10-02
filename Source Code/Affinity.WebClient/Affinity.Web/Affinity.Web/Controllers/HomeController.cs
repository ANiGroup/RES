using Affinity.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Affinity.Web.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index(int mId=1)
        {
            ViewBag.Title = "Home Page";
            DbModel db = new DbModel();
            var m = db.AffiReports.Where(o => o.Id == mId).FirstOrDefault();
            return View(m);
        }
    }
}
