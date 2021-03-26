using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunKatalog.MvcWebApp.Entity;
using UrunKatalog.MvcWebApp.Identity;
using UrunKatalog.MvcWebApp.Models;

namespace UrunKatalog.MvcWebApp.Controllers
{
    public class AccountController : Controller
    {
        public DataContext DC = new DataContext();

        private UserManager<ApplicationUser> UserManager;

        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;

            
            var order = DC.Orders.Where(i => i.Username == username)
                .Select(i=> new UseOrderModel()
                {
                    Id = i.Id,
                    OrderNumber = i.OrderNumber,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    Total = i.Total
                })
                .OrderByDescending(i=>i.OrderDate)      //order date göre tersten sıralayıp öyle göndermek için bunu yapıyoruz.
                .ToList();
            return View(order);     //Olusturdugumuz ordersi viewe gönderiyoruz.
        }
        //get
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register R1)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.Name = R1.Name;
                user.Surname = R1.SurName;
                user.Email = R1.Email;
                user.UserName = R1.UserName;

                var result = UserManager.Create(user, R1.Password);

                //kullanıcı oluştuysa
                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("user"))
                    {
                        //rol ataması oluyor
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı kayıt sırasında hata oluştu.");
                }
            }

            return View(R1);
        }


        //get
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login L1 )
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(L1.UserName, L1.Password);


                if (user != null)
                {
                    //cookie işlemleri
                    var authManager = HttpContext.GetOwinContext().Authentication;

                    var identityClaims = UserManager.CreateIdentity(user, "ApplicationCookie");

                    //var claim2 = UserManager.AddClaim( , identityClaims);

                    var authProperties = new AuthenticationProperties();

                    authProperties.IsPersistent = L1.RememberMe;

                    authManager.SignIn(authProperties, identityClaims);

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı kayıt sırasında hata oluştu.");
                }
            }
                

            return View(L1);
        }

        public ActionResult Logout()
        {
            //cookie yi yakalamak için 
            var authManager = HttpContext.GetOwinContext().Authentication;

            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int id)
        {
            var entity = DC.Orders
                .Where(i => i.Id == id)
                .Select(i=>new OrderDetailsModel()
                {
                    DetailsId = i.Id,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    OrderDate = i.OrderDate,
                    AdresBasligi = i.AdresBasligi,
                    Adres = i.Adres,
                    Sehir = i.Sehir,
                    Semt = i.Semt,
                    PostaKodu = i.Postakodu,
                    Orderlines = i.Orderlines.Select(a=>new OrderLineModel()
                    {
                        ProductId = a.ProductId,
                        ProductName = a.Product.Name,
                        Image = a.Product.Image,
                        Quantity = a.Quantity,
                        Price = a.Price
                    }).ToList()
                })
                .FirstOrDefault();

            return View(entity);
        }
    }
}