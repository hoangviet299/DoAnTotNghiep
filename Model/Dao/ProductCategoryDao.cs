using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class ProductCategoryDao
    {
        ShopVanPhongPhamDBContext db = null;
        public ProductCategoryDao()
        {
            db = new ShopVanPhongPhamDBContext();
        }
        public List<category> ListAll()
        {
            return db.categories.ToList();
        }
    }
}
