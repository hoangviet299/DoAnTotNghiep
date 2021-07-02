using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class SuppliersDao
    {
        ShopVanPhongPhamDBContext db = null;
        public SuppliersDao()
        {
            db = new ShopVanPhongPhamDBContext();

        }
        public long Insert(supplier entity)
        {
            db.suppliers.Add(entity);
            db.SaveChanges();
            return entity.id_suppliers;
        }
        public IEnumerable<supplier> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<supplier> model = db.suppliers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.name.Contains(searchString) || x.name.Contains(searchString));

            }
            return model.OrderByDescending(x => x.created_at).ToPagedList(page, pageSize);
        }
        public supplier GetbyID(string SuppliersName)
        {
            return db.suppliers.SingleOrDefault(x => x.name == SuppliersName);
        }

        public supplier ViewDetail(long id)
        {
            return db.suppliers.Find(id);
        }
        public bool Update(supplier entity)
        {
            try
            {
                var Suppliers = db.suppliers.Find(entity.id_suppliers);
                Suppliers.id_suppliers = entity.id_suppliers;
                Suppliers.name = entity.name;
                Suppliers.email = entity.email;
                Suppliers.website = entity.website;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /*public bool Login(string SuppliersName, string passWord)
        {
            var result = db.Supplierss.Count(x => x.email == SuppliersName && x.password == passWord);
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
                var Suppliers = db.suppliers.Find(id);
                db.suppliers.Remove(Suppliers);
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
