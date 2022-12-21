using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVCDapperKutuphane.Models
{
    public class OgrenciModel
    {
        [DisplayName("Öğrenci No")]
        public int OgrenciNo { get; set; }
        [DisplayName("Öğrenci Adı Soyadı")]
        public string OgrenciAdSoyad { get; set; }
        public string Cinsiyet { get; set; }
        [DisplayName("Doğum Tarihi")]
        public string DTarihi { get; set; }
        [DisplayName("Bölüm")]
        public string Bolum { get; set; }
       
    }
}