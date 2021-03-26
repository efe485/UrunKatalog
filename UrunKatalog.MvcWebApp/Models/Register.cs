using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UrunKatalog.MvcWebApp.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Soyadınız")]
        public string SurName { get; set; }

        [Required]
        [DisplayName("Mail Adresi")]
        //mail adresinin formatı
        [EmailAddress(ErrorMessage ="eMail alanını düzgün giriniz.")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Şifre Tekrar")]
        //şifre kontrol
        [Compare("Password" , ErrorMessage ="Şifreler aynı değil.")]
        [DataType(DataType.Password)]
        public string Repassword { get; set; }
    }
}