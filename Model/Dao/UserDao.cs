using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class UserDao
    {
        ShopVanPhongPhamDBContext db = null;
        public UserDao()
        {
            db = new ShopVanPhongPhamDBContext();

        }
        public long Insert(user entity)
        {
            db.users.Add(entity);
            db.SaveChanges();
            return entity.id_user;
        }
        public IEnumerable<user> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<user> model = db.users;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.name.Contains(searchString) || x.name.Contains(searchString));

            }    
            return model.OrderByDescending(x=>x.created_at).ToPagedList(page, pageSize);
        }

        public long Insert(news news)
        {
            throw new NotImplementedException();
        }

        public user GetbyID(string userName)
        {
            return db.users.SingleOrDefault(x=>x.name == userName);
        }

        public user ViewDetail(long id)
        {
            return db.users.Find(id);
        }
        public bool Update(user entity)
        {
            try
            {
                var user = db.users.Find(entity.id_user);
                user.id_user = entity.id_user;
                user.name = entity.name;
                user.email = entity.email;
                user.address = entity.address;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool Login(string userName, string passWord)
        {
            var result = db.users.Count(x => x.name == userName && x.password == passWord);
            if(result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.users.Find(id);
                db.users.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool CheckUserName(string name)
        {
            return db.users.Count(x => x.name == name) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.users.Count(x => x.email == email) > 0;
        }
    }
}
