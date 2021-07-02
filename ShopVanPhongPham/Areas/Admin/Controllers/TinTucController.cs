using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopVanPhongPham.Areas.Admin.Controllers
{
    public class TinTucController : Controller
    {
        // GET: Admin/TinTuc
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new TinTucDao();
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
        public ActionResult Create(news news)
        {
            if (ModelState.IsValid)
            {
                var dao = new TinTucDao();
                long id = dao.Insert(news);

                if (id > 0)
                {
                    return RedirectToAction("Index", "TinTuc");
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
            var news = new TinTucDao().ViewDetail(id);
            return View(news);
        }
        [HttpPost]
        public ActionResult Edit(news news)
        {
            if (ModelState.IsValid)
            {
                var dao = new TinTucDao();
                var result = dao.Update(news);

                if (result)
                {
                    return RedirectToAction("Index", "TinTuc");
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
            var news = new TinTucDao().ViewDetail(id);
            return View(news);
        }
        public ActionResult Delete(int id)
        {
            new TinTucDao().Delete(id);
            return RedirectToAction("Index");
        }
        /*public ActionResult Detail(string id)
        {
            List<Product> ds = pr.getOnProduct(id);
            return View(ds.FirstOrDefault());
        }*/
    }
}