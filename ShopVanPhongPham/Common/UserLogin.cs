﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopVanPhongPham.Common
{
    [Serializable]
    public class UserLogin
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
}