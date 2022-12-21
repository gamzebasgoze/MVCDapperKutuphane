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
    public class IslemController : Controller
    {
        // GET: Islem
        public ActionResult Index()
        {
            return View(DP.ReturnList<IslemModel>("IslemListele"));
        }
        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@İslemNo", id);
                return View(DP.ReturnList<IslemModel>("IslemNosirala", param).FirstOrDefault<IslemModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(IslemModel islem)
        {
            //view oluştururken edit olanı seçiyoruz
            DynamicParameters param = new DynamicParameters();
            param.Add("İslemNo", islem.İslemNo);
            param.Add("AlısTarihi", islem.AlısTarihi);
            param.Add("TeslimTarihi", islem.TeslimTarihi);
            param.Add("OgrenciNo", islem.OgrenciNo);
            param.Add("KitapNo", islem.KitapNo);

            DP.ExecuteWReturn("IslemEY", param);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@İslemNo", id);
            DP.ExecuteWReturn("ISil", param);
            return RedirectToAction("Index");
        }

    }
}