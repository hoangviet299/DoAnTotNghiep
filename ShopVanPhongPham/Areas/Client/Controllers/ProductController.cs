using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Dao;
using System.Web.Mvc;

namespace ShopVanPhongPham.Areas.Client.Controllers
{
    public class ProductController : Controller
    {
        // GET: Client/Product
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDao().ListAll();

            return PartialView(model);
        }
        public ActionResult Detail(int id)
        {
            var product = new ProductDao().ViewDetail(id);
            ViewBag.Category = new CategoryDao().ViewDetail(product.id_category.Value);
            ViewBag.supplier = new SuppliersDao().ViewDetail(product.id_supplies.Value);
            ViewBag.RelateProsucts = new ProductDao().ListRelateProduct(id);
            return View(product);
        }
        public ActionResult ListFeatureProductFull()
        {
            var prohotfull = new ProductDao().ListFeatureProductFull();
            return View(prohotfull);
        }
        public ActionResult Category(int id, int page = 1, int pageSize = 10)
        {
            ViewBag.Slides = new SlideDao().ListAll();
            var category = new CategoryDao().ViewDetail(id);
            ViewBag.Category = category;
            int totalRecord = 0;
            var model = new ProductDao().ListByCategoryID(id,ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / (double)pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
        public JsonResult ListName(string q)
        
        {
            var data = new ProductDao().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(string keyword, int page = 1, int pageSize = 1)
        {
            int totalRecord = 0;
            var model = new ProductDao().Search(keyword, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.Keyword = keyword;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / (double)pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
        
        public ActionResult ListProduct( int page = 1, int pageSize = 15)
        {
            ViewBag.Slides = new SlideDao().ListAll();
            int totalRecord = 0;
            var model = new ProductDao().ListProduct(ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / (double)pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }

    }
}