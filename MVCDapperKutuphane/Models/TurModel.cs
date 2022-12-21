using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVCDapperKutuphane.Models
{
    public class TurModel
    {
        [DisplayName("Tür No")]
        public int TurNo { get; set; }
        [DisplayName("Türü")]
        public string TurAdı { get; set; }
       
    }
}