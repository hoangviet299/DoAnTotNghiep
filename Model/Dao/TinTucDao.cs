using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class TinTucDao
    {
        ShopVanPhongPhamDBContext db = null;
        public TinTucDao()
        {
            db = new ShopVanPhongPhamDBContext();

        }
        public long Insert(news entity)
        {
            db.news.Add(entity);
            db.SaveChanges();
            return entity.id_new;
        }
        public IEnumerable<news> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<news> model = db.news;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.name.Contains(searchString) || x.name.Contains(searchString));

            }
            return model.OrderByDescending(x => x.created_at).ToPagedList(page, pageSize);
        }
        public news GetbyID(string newsName)
        {
            return db.news.SingleOrDefault(x => x.name == newsName);
        }

        public news ViewDetail(long id)
        {
            return db.news.Find(id);
        }
        public bool Update(news entity)
        {
            try
            {
                var news = db.news.Find(entity.id_new);
                news.id_new = entity.id_new;
                news.name = entity.name;
                news.description = entity.description;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var news = db.news.Find(id);
                db.news.Remove(news);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<news> ListTinTuc()
        {
            return db.news.OrderByDescending(x => x.id_new).ToList();
        }
        public news ViewDetail(int id)
        {
            return db.news.Find(id);
        }
    }
}
