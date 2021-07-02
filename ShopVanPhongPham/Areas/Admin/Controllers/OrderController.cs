using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace ShopVanPhongPham.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            ViewBag.order = new OrderDetailDao().ListAll();
            var dao = new OrderDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(order order)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDao();
                long id = dao.Insert(order);

                if (id > 0)
                {
                    return RedirectToAction("Index", "Order");
                }
                else
                {
                    ModelState.AddModelError("", "Không Thành công");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var order = new OrderDao().ViewDetail(id);
            return View(order);
        }
        [HttpPost]
        public ActionResult Edit(order order)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDao();
                var result = dao.Update(order);

                if (result)
                {
                    return RedirectToAction("Index", "Order");
                }
                else
                {
                    ModelState.AddModelError("", "Không thành công");
                }
            }
            return View("Index");
        }
        /*[HttpDelete]*/
        public ActionResult Detail(int id)
        {
            var order_detail = new OrderDetailDao().ViewDetail(id);
            ViewBag.order = new OrderDao().ViewDetail(order_detail.id_order.Value);
            ViewBag.product = new ProductDao().ViewDetail(order_detail.id_product.Value);
            return View(order_detail);
            /*var orderdetail = new OrderDetailDao().ViewDetail(id);
            ViewBag.order = new OrderDao().ViewDetail(orderdetail.id_order.Value);
            ViewBag.product = new ProductDao().ViewDetail(orderdetail.id_product.Value);
            return View(orderdetail);*/
        }
        public ActionResult Delete(int id)
        {
            new OrderDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}