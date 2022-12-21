using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVCDapperKutuphane.Models
{
    public class KitaplarModel
    {
        [DisplayName("Kitap No")]
        public int KitapNo { get; set; }
        [DisplayName("Isbn Numarası")]
        public int IsbnNo { get; set; }
        [DisplayName("Kitap Adı")]
        public string KitapAdi { get; set; }
        [DisplayName("Sayfa Sayısı")]
        public int SayfaSayisi { get; set; }
        [DisplayName("Yazar No")]
        public int YazarNo { get; set; }
        [DisplayName("Tür No")]
        public int TurNo { get; set; }    
    }
}