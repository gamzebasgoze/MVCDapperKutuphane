using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVCDapperKutuphane.Models
{
    public class YazarlarModel
    {
        [DisplayName("Yazar No")]
        public int YazarNo { get; set; }
        [DisplayName("Yazar Adı")]
        public string YazarAd { get; set; }
        [DisplayName("Yazar Soyadı")]
        public string YazarSoyad { get; set; }
    }
}
