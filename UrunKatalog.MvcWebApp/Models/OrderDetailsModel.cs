using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrunKatalog.MvcWebApp.Entity;

namespace UrunKatalog.MvcWebApp.Models
{
    public class OrderDetailsModel
    {
        public int DetailsId { get; set; }          
        public string Username { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }
        
        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }
        public virtual List<OrderLineModel> Orderlines { get; set; }     //Aynı siparis içinde birden fazla order line olabilir

    }

    public class OrderLineModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}