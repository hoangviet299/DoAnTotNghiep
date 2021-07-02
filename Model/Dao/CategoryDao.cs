using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class CategoryDao
    {
        ShopVanPhongPhamDBContext db = null;
        public CategoryDao()
        {
            db = new ShopVanPhongPhamDBContext();

        }
        public long Insert(category entity)
        {
            db.categories.Add(entity);
            db.SaveChanges();
            return entity.id_category;
        }
        public IEnumerable<category> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<category> model = db.categories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.name.Contains(searchString) || x.name.Contains(searchString));

            }
            return model.OrderByDescending(x => x.created_at).ToPagedList(page, pageSize);
        }
        public category GetbyID(string CategoryName)
        {
            return db.categories.SingleOrDefault(x => x.name == CategoryName);
        }

        public category ViewDetail(long id)
        {
            return db.categories.Find(id);
        }
        public bool Update(category entity)
        {
            try
            {
                var Category = db.categories.Find(entity.id_category);
                Category.id_category = entity.id_category;
                Category.name = entity.name;
                Category.icon = entity.icon;
                Category.avatar = entity.avatar;
                Category.active = entity.active;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /*public bool Login(string CategoryName, string passWord)
        {
            var result = db.Categorys.Count(x => x.email == CategoryName && x.password == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/
        public bool Delete(int id)
        {
            try
            {
                var Category = db.categories.Find(id);
                db.categories.Remove(Category);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
