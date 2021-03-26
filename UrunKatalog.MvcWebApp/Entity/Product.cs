using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UrunKatalog.MvcWebApp.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        [DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        [StringLength(maximumLength: 10, ErrorMessage = "10 karakterdn fazla giremezsiniz")]
        public string Image { get; set; }
        public bool isHome { get; set; }
        public bool isApproved { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}