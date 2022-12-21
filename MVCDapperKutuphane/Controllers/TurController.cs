using Dapper;
using MVCDapper.Models;
using MVCDapperKutuphane.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDapperKutuphane.Controllers
{
    public class TurController : Controller
    {
        // GET: Tur
        public ActionResult Index()
        {
            return View(DP.ReturnList<TurModel>("TurListele"));
        }
        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@TurNo", id);
                return View(DP.ReturnList<TurModel>("TurNoSirala", param).FirstOrDefault<TurModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(TurModel tur)
        {
            //view oluştururken edit olanı seçiyoruz
            DynamicParameters param = new DynamicParameters();
            param.Add("TurNo", tur.TurNo);
            param.Add("TurAdı", tur.TurAdı);
            

            DP.ExecuteWReturn("TurEY", param);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@TurNo", id);
            DP.ExecuteWReturn("TSil", param);
            return RedirectToAction("Index");
        }
    }
}