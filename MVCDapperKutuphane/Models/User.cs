using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDapperKutuphane.Models
{
    public class User
    {
        [Required]
        [Display(Name ="Kullanıcı Adı")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password1 { get; set; }
    }
}