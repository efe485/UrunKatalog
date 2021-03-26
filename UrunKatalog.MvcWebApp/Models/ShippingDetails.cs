using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UrunKatalog.MvcWebApp.Models
{
    public class ShippingDetails
    {
        public string Username { get; set; }

        [Required(ErrorMessage ="Adres tipini giriniz")]
        public string AdresBasligi { get; set; }
        [Required(ErrorMessage = "Adres giriniz")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Şehir giriniz")]
        public string Sehir { get; set; }
        [Required(ErrorMessage = "Semt giriniz")]
        public string Semt { get; set; }
        [Required(ErrorMessage = "Mahalle giriniz")]
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }

        public string eMail { get; set; }
        public string Telefon { get; set; }
    }
}