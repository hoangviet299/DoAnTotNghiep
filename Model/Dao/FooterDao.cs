using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class FooterDao
    {
        ShopVanPhongPhamDBContext db = null;
        public FooterDao()
        {
            db = new ShopVanPhongPhamDBContext();
        }
        public footer GetFooter()
        {
            return db.footers.SingleOrDefault(x => x.status == true);
        }
    }
    
}
