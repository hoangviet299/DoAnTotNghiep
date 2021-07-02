using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace ShopVanPhongPham.Areas.Admin.Controllers
{
    public class SlideController : Controller
    {
        // GET: Admin/Slide
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new SlideDao();
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
        public ActionResult Create(Slide Slide)
        {
            if (ModelState.IsValid)
            {
                var dao = new SlideDao();
                long id = dao.Insert(Slide);

                if (id > 0)
                {
                    return RedirectToAction("Index", "Slide");
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
            var Slide = new SlideDao().ViewDetail(id);
            return View(Slide);
        }
        [HttpPost]
        public ActionResult Edit(Slide Slide)
        {
            if (ModelState.IsValid)
            {
                var dao = new SlideDao();
                var result = dao.Update(Slide);

                if (result)
                {
                    return RedirectToAction("Index", "Slide");
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
            var Slide = new SlideDao().ViewDetail(id);
            return View(Slide);
        }
        public ActionResult Delete(int id)
        {
            new SlideDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}