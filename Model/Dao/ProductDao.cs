using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class ProductDao
    {
        ShopVanPhongPhamDBContext db = null;
        public ProductDao()
        {
            db = new ShopVanPhongPhamDBContext();

        }
        public int Insert(product entity)
        {
            db.products.Add(entity);
            db.SaveChanges();
            return entity.id_product;
        }
        public IEnumerable<product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<product> model = db.products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.name.Contains(searchString) || x.name.Contains(searchString));

            }
            return model.OrderByDescending(x => x.created_at).ToPagedList(page, pageSize);
        }
        public product GetbyID(string ProductName)
        {
            return db.products.SingleOrDefault(x => x.name == ProductName);
        }

        
        public bool Update(product entity)
        {
            try
            {
                var Product = db.products.Find(entity.id_product);
                Product.id_product = entity.id_product;
                Product.name = entity.name;
                Product.price = entity.price;
                Product.vieww = entity.vieww;
                Product.description = entity.description;
                Product.contentt = entity.contentt;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /*public bool Login(string ProductName, string passWord)
        {
            var result = db.products.Count(x => x.email == ProductName && x.password == passWord);
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
                var Product = db.products.Find(id);
                db.products.Remove(Product);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<product> ListFeatureProductFull()
        {
            return db.products.Where(x => x.hot != null).OrderByDescending(x => x.hot).ToList();
        }
        public List<product> ListNewProduct(int top)
        {
            return db.products.OrderByDescending(x => x.created_at).Take(top).ToList();
        }
        public List<product> ListFeatureProduct(int top)
        {
            return db.products.Where(x => x.hot != null).OrderByDescending(x => x.hot).Take(top).ToList();
        }
        public List<product> ListRelateProduct(int productID)
        {
            var product = db.products.Find(productID);
            return db.products.Where(x => x.id_product != productID && x.id_category == product.id_category).OrderByDescending(x => x.created_at).Take(4).ToList();
        }
        public product ViewDetail(int id)
        {
            return db.products.Find(id);
        }
        public List<product> ListByCategoryID(long idcate,ref int totalRecord, int pageIndex = 1, int pageSize = 10)
        {
            totalRecord = db.products.Where(x => x.id_category == idcate).Count();
            var model = db.products.Where(x => x.id_category == idcate).OrderByDescending(x=>x.created_at).Skip((pageIndex -1)*pageSize).Take(pageSize).ToList();
            return model;
        }
        public List<string> ListName(string keyword)
        {
            return db.products.Where(x => x.name.Contains(keyword)).Select(x => x.name).ToList();
        }
        public List<product> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.products.Where(x => x.name == keyword).Count();
            var model = db.products.Where(x => x.name.Contains(keyword)).OrderByDescending(x => x.created_at).Skip((pageSize - 1) * pageIndex).Take(pageSize).ToList();
            return model;
        }
        public List<product> ListProduct(ref int totalRecord, int pageIndex = 1, int pageSize = 15)
        {
            totalRecord = db.products.Count();
            var model =  db.products.OrderByDescending(x => x.id_product).Skip((pageIndex - 1)*pageSize).Take(pageSize).ToList();
            return model;
        }
    }
}
