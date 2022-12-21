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
    public class YazarController : Controller
    {
        // GET: Yazar
        public ActionResult Index()
        {
            return View(DP.ReturnList<YazarlarModel>("YazarListele"));
        }
        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@YazarNo", id);
                return View(DP.ReturnList<YazarlarModel>("YazarNoSirala", param).FirstOrDefault<YazarlarModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(YazarlarModel yazarlar)
        {
            //view oluştururken edit olanı seçiyoruz
            DynamicParameters param = new DynamicParameters();
            param.Add("YazarNo", yazarlar.YazarNo);
            param.Add("YazarAd", yazarlar.YazarAd);
            param.Add("YazarSoyad", yazarlar.YazarSoyad);

            DP.ExecuteWReturn("YazarEY", param);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@YazarNo", id);
            DP.ExecuteWReturn("YSil", param);
            return RedirectToAction("Index");
        }
    }
}