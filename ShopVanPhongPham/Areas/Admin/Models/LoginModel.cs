using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopVanPhongPham.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Mời nhập Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}