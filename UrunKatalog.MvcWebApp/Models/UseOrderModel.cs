using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrunKatalog.MvcWebApp.Entity;

namespace UrunKatalog.MvcWebApp.Models
{
    public class UseOrderModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        //Enum Gelecek buraya
        public EnumOrderState OrderState { get; set; }
    }
}