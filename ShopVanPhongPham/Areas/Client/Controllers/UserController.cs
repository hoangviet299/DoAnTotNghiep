using Model.Dao;
using ShopVanPhongPham.Areas.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using ShopVanPhongPham.Common;
using ShopVanPhongPham.Areas.Admin.Controllers;

namespace ShopVanPhongPham.Areas.Client.Controllers
{
    public class UserController : Controller
    {
        // GET: Client/User
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Slides = new SlideDao().ListAll();
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Slides = new SlideDao().ListAll();
            return View();
        }
        public ActionResult Logout()
        {
            Session[CommonCOnstants.USER_SESSION] = null;
            return Redirect("/Client/Home");
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)//kiểm tra dữ liệu có hợp lệ không?
            {
                var dao = new UserDao();
                var result = dao.Login(model.name, model.password);
                if (result)
                {
                    var user = dao.GetbyID(model.name);
                    var userSession = new UserLogin();
                    userSession.UserName = user.name;
                    userSession.UserID = user.id_user;

                    Session.Add(CommonCOnstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập không đúng");

                }
            }

            return View(model);
        }

        [HttpPost]
       /* [CaptchaValidation("CaptchaCode", "registerCapcha", "Mã xác nhận không đúng!")]*/
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckUserName(model.name))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.CheckEmail(model.email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new user();
                    user.name = model.name;
                    user.password = model.password;
                    user.phone = model.phone;
                    user.email = model.email;
                    user.created_at = DateTime.Now;
                    /*user.Status = true;*/
                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }
                }
            }
            return View(model);
        }
    }
}