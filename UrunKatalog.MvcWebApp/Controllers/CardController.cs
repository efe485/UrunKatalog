using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunKatalog.MvcWebApp.Entity;
using UrunKatalog.MvcWebApp.Models;

namespace UrunKatalog.MvcWebApp.Controllers
{
    public class CardController : Controller
    {
        public DataContext DC = new DataContext();


        // GET: Card
        public ActionResult Index()
        {
            return View(GetCard());
        }

        public ActionResult AddToCard(int Id)
        {
            var product = DC.Products.FirstOrDefault(i => i.Id == Id);

            if (product != null)
            {
                GetCard().AddProduct(product, 1);
            }

            return RedirectToAction("List","Home");
        }


        public ActionResult DeleteFromCard(int Id)
        {
            var product = DC.Products.FirstOrDefault(i => i.Id == Id);

            if (product != null)
            {
                GetCard().DeleteProduct(product);
            }

            return RedirectToAction("Index");
        }

        public Card GetCard()
        {
            var card = (Card)Session["Card"];

            if (card == null)
            {
                card = new Card();
                Session["Card"] = card ;
            }
            return card;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCard());
        }

        //bu kısma dön
        //get
        [Authorize]
        public ActionResult Checkout()
        {
            //
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var card = GetCard();

            if(card.CardLines.Count == 0)
            {
                ModelState.AddModelError("EmptyBoxError", "Sepetinize ürün bulunmamaktadır.");
            }

            if (ModelState.IsValid)
            {
                SaveOrder(card, entity);
                card.ClearCard();

                return View("Completed");
            }
            else
            {
                return View(entity);
            }
        }


        public ActionResult SaveOrder( Card cart , ShippingDetails entity)
        {
            var order = new Order();

            order.OrderNumber = "A" + (new Random()).Next(10000, 99999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.Username = User.Identity.Name;
            order.OrderState = EnumOrderState.Waiting;      //Sparis ilk acıldıgında bekliyor olarak gelecek.

            order.AdresBasligi = entity.AdresBasligi;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Semt = entity.Semt;
            order.Mahalle = entity.Mahalle;
            order.Postakodu = entity.PostaKodu;

            order.Orderlines = new List<OrderLine>();

            foreach (var item in cart.CardLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = item.Quantity;
                orderline.Price = item.Product.Price * item.Quantity;
                orderline.ProductId = item.Product.Id;
                order.Orderlines.Add(orderline);
                DC.OrderLines.Add(orderline);

                Product changeRow = DC.Products.Where(i => i.Id == item.Product.Id)
                    .FirstOrDefault();

                changeRow.Stock -= item.Quantity;

                if (changeRow.Stock==0)
                {
                    changeRow.isApproved = false;
                }
            }

            DC.Orders.Add(order);
            
            DC.SaveChanges();

            return View();
        }

    }


}