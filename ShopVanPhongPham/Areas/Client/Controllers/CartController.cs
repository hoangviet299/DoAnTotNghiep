using Model.Dao;
using ShopVanPhongPham.Areas.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using Model.EF;
using System.Configuration;

namespace ShopVanPhongPham.Areas.Client.Controllers
{
    public class CartController : Controller
    {
        ShopVanPhongPhamDBContext db = new ShopVanPhongPhamDBContext();
        public CartItem GetCart()
        {
            CartItem cart = Session["Cart"] as CartItem;
            if(cart == null || Session["Cart"] == null)
            {
                cart = new CartItem();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddtoCart(int id)
        {
            var pro = db.products.SingleOrDefault(s => s.id_product == id);
            if(pro != null)
            {
                GetCart().AddCart(pro);
            }
            return RedirectToAction("Index", "Cart");
        }
        public  ActionResult Index()
        {
            ViewBag.Slides = new SlideDao().ListAll();
            if (Session["Cart"] == null)
                return RedirectToAction("Index", "Cart");
            CartItem cart = Session["Cart"] as CartItem;
            return View(cart);
        }
        public ActionResult Update(FormCollection form)
        {
            CartItem cart = Session["Cart"] as CartItem;
            int id_pro = int.Parse(form["ID_Product"]);
            int quantity = int.Parse(form["quantity"]);
            cart.Update(id_pro, quantity);
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult Remove(int id)
        {
            CartItem cart = Session["Cart"] as CartItem;
            cart.Remove(id);
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult ClearCart()
        {
            CartItem cart = Session["Cart"] as CartItem;
            cart.ClearCart();
            return RedirectToAction("Index", "Cart");
        }
        [HttpGet]
        public ActionResult Payment()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("Index", "Cart");
            CartItem cart = Session["Cart"] as CartItem;
            return View(cart);
        }
        [HttpPost]
        public ActionResult Payment(FormCollection form)
        {
            try
            {
                CartItem cart = Session["Cart"] as CartItem;
                order order = new order();
                order.create_date = DateTime.Now;
                order.shipname = form["shipName"];
                order.id_customer = int.Parse(form["idcustomer"]);
                order.shipmobie = form["mobile"];
                order.shipaddress = form["address"];
/*                order.shipemail = form["email"];
*/                db.orders.Add(order);
                foreach(var item in cart.Items)
                {
                    orderDetail orderDetail = new orderDetail();
                    orderDetail.id_order = order.id_order;
                    orderDetail.id_product = item.Product.id_product;
                    orderDetail.price = item.Product.price;
                    orderDetail.quantity = item.Quantity;
                    db.orderDetails.Add(orderDetail);
                }
                db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("Success", "Cart");
            }
            catch
            {
                return RedirectToAction("Error", "Cart");
            }
        }
        //public static string CartSession = "CartSession";//key để lưu biến session
        // GET: Client/Cart
        /*public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }*/

        /*public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }*/
        public PartialViewResult HeaderCart()
        {
            int t_item = 0;
            CartItem cart = Session["Cart"] as CartItem;
            if(cart != null)
            {
                t_item = cart.Total_Quantity();
            }
            ViewBag.infoCart = t_item;
            return PartialView("HeaderCart");
        }
        /*public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.id_product == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.id_product == item.Product.id_product);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult AddItem(long productId, int quantity)
        {
            var product = new ProductDao().ViewDetail(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.id_product == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.Product.id_product == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.Product = product;
                item.Product.vieww = quantity;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        */
        /*[HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string address, string email)
        {
            var order = new order();
            order.create_date = DateTime.Now;
            order.shipaddress = address;
            order.shipmobie = mobile;
            order.shipname = shipName;
            order.shipemail = email;

            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new OrderDetailDao();
                *//*decimal total = 0;*//*
                foreach (var item in cart)
                {
                    var orderDetail = new orderDetail();
                    orderDetail.id_product = item..id_product;
                    orderDetail.id_order = id;
                    orderDetail.price = item.Pro.price;
                    orderDetail.quantity = item.Quantity;
                    detailDao.Insert(orderDetail);

                    *//*total += (item.Product.price.GetValueOrDefault(0) * item.Quantity);*//*
                }
                *//*string content = System.IO.File.ReadAllText(Server.MapPath("~/assets/client/template/neworder.html"));

                content = content.Replace("{{CustomerName}}", shipName);
                content = content.Replace("{{Phone}}", mobile);
                content = content.Replace("{{Email}}", email);
                content = content.Replace("{{Address}}", address);
                content = content.Replace("{{Total}}", total.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(email, "Đơn hàng mới từ OnlineShop", content);
                new MailHelper().SendMail(toEmail, "Đơn hàng mới từ OnlineShop", content);*//*
            }
            catch (Exception ex)
            {
                //ghi log
                return Redirect("Error");
            }
            return Redirect("Success");
        }
        */
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}