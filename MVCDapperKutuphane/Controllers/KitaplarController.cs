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
    public class KitaplarController : Controller
    {
        // GET: Kitaplar
        public ActionResult Index()
        {
            return View(DP.ReturnList<KitaplarModel>("KitapListele"));
        }
        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@KitapNo", id);
                return View(DP.ReturnList<KitaplarModel>("KitapNoSirala", param).FirstOrDefault<KitaplarModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(KitaplarModel kitaplar)
        {
            //view oluştururken edit olanı seçiyoruz
            DynamicParameters param = new DynamicParameters();
            param.Add("KitapNo", kitaplar.KitapNo);
            param.Add("IsbnNo", kitaplar.IsbnNo);
            param.Add("KitapAdi", kitaplar.KitapAdi);
            param.Add("SayfaSayisi", kitaplar.SayfaSayisi);
            param.Add("YazarNo", kitaplar.YazarNo);
            param.Add("TurNo", kitaplar.TurNo);

            DP.ExecuteWReturn("KitapEY", param);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@KitapNo", id);
            DP.ExecuteWReturn("KSil", param);
            return RedirectToAction("Index");
        }
    }
}