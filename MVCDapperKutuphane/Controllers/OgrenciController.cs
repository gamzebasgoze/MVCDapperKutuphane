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
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        public ActionResult Index()
        {
            return View(DP.ReturnList<OgrenciModel>("OgrenciListele"));
        }
        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@OgrenciNo", id);
                return View(DP.ReturnList<OgrenciModel>("OgrenciNoSirala", param).FirstOrDefault<OgrenciModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(OgrenciModel ogrenci)
        {
            //view oluştururken edit olanı seçiyoruz
            DynamicParameters param = new DynamicParameters();
            param.Add("OgrenciNo", ogrenci.OgrenciNo);
            param.Add("OgrenciAdSoyad", ogrenci.OgrenciAdSoyad);
            param.Add("Cinsiyet", ogrenci.Cinsiyet);
            param.Add("DTarihi", ogrenci.DTarihi);
            param.Add("Bolum", ogrenci.Bolum);

            DP.ExecuteWReturn("OgrenciEY", param);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@OgrenciNo", id);
            DP.ExecuteWReturn("OSil", param);
            return RedirectToAction("Index");
        }
    }
}