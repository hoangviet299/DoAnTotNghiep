using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;

namespace ShopVanPhongPham.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        // GET: Admin/Menu
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new MenuDao();
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
        public ActionResult Create(Menu Menu)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuDao();
                long id = dao.Insert(Menu);

                if (id > 0)
                {
                    return RedirectToAction("Index", "Menu");
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
            var Menu = new MenuDao().ViewDetail(id);
            return View(Menu);
        }
        [HttpPost]
        public ActionResult Edit(Menu Menu)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuDao();
                var result = dao.Update(Menu);

                if (result)
                {
                    return RedirectToAction("Index", "Menu");
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
            var Menu = new MenuDao().ViewDetail(id);
            return View(Menu);
        }
        public ActionResult Delete(int id)
        {
            new MenuDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}