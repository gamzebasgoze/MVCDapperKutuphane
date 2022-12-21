using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDapperKutuphane.Controllers
{
    public class AdminController : Controller
    {
        [Authorize]
        // GET: Admin
        public ActionResult Admin()
        {
            return View();
        }
    }
}