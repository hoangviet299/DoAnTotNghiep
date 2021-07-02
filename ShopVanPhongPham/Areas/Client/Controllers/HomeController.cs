using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Dao;
using System.Web.Mvc;
using ShopVanPhongPham.Areas.Client.Models;

namespace ShopVanPhongPham.Areas.Client.Controllers
{
    public class HomeController : Controller
    {
        // GET: Client/Home
        private const string CartSession = "CartSession";
        public ActionResult Index()
        {
            ViewBag.Slides = new SlideDao().ListAll();
            var productDao = new ProductDao();
            ViewBag.NewProducts = productDao.ListNewProduct(5);
            ViewBag.ListFeatureProducts = productDao.ListFeatureProduct(5);
            return View();
        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupId(1);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var model = new MenuDao().ListByGroupId(2);
            return PartialView(model);
        }
        public ActionResult Slide()
        {
            ViewBag.Slides = new SlideDao().ListAll();
            return View();
        }
        /*[ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }*/
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterDao().GetFooter();
            return PartialView(model);
        }
        public ActionResult GioiThieu()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            return View();
        }
    }
}