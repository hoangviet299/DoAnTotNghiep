using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ShopVanPhongPham.Areas.Client.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { set; get; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]

        public string name { set; get; }

        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự.")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string password { set; get; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("password", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string confirmName { set; get; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
        public string firrstName { set; get; }

        [Display(Name = "Địa chỉ")]
        public string address { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập email")]
        [Display(Name = "Email")]
        public string email { set; get; }
        [Display(Name = "Điện thoại")]
        public string phone { set; get; }
    }
}