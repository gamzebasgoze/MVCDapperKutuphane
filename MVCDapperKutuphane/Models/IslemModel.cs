using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVCDapperKutuphane.Models
{
    public class IslemModel
    {
        [DisplayName("İşlem No")]
        public int İslemNo { get; set; }
        [DisplayName("Alış Tarihi")]
        public string AlısTarihi { get; set; }
        [DisplayName("Teslim Tarihi")]
        public string TeslimTarihi { get; set; }
        [DisplayName("Öğrenci No")]
        public int OgrenciNo { get; set; }
        [DisplayName("Kitap No")]
        public int KitapNo { get; set; }
    }
}