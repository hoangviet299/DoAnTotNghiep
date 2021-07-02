using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace ShopVanPhongPham.Areas.Client.Controllers
{
    public class TinTucController : Controller
    {
        // GET: Client/TinTuc
        public ActionResult Index()
        {
            ViewBag.listTintuc = new TinTucDao().ListTinTuc();
            return View();
        }
        public ActionResult Detail(int id)
        {
            var tintuc = new TinTucDao().ViewDetail(id);
            return View(tintuc);
        }
    }
}