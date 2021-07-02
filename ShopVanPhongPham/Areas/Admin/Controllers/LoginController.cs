using Model.Dao;
using ShopVanPhongPham.Areas.Admin.Models;
using ShopVanPhongPham.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopVanPhongPham.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
/*        [ValidateAntiForgeryToken]
*/        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.email, model.Password);
                if (result)
                {
                    var user = dao.GetbyID(model.email);
                    var userSession = new UserLogin();
                    userSession.UserName = user.email;
                    userSession.UserID = user.id_user;

                    Session.Add(CommonCOnstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập không đúng");

                }
            }
            
            return View("Index");
        }
    }
}