using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public  class OrderDao
    {
        ShopVanPhongPhamDBContext db = null;
        public OrderDao()
        {
            db = new ShopVanPhongPhamDBContext();
        }
        public int Insert(order order)
        {
            db.orders.Add(order);
            db.SaveChanges();
            return order.id_order;
        }
        public IEnumerable<order> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<order> model = db.orders;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.shipname.Contains(searchString) || x.shipname.Contains(searchString));

            }
            return model.OrderByDescending(x => x.create_date).ToPagedList(page, pageSize);
        }
        public order GetbyID(string orderName)
        {
            return db.orders.SingleOrDefault(x => x.shipname == orderName);
        }

        public order ViewDetail(int id)
        {
            return db.orders.Find(id);
        }
        public bool Update(order entity)
        {
            try
            {
                var order = db.orders.Find(entity.id_order);
                order.id_order = entity.id_order;
                order.shipname = entity.shipname;
                order.shipmobie = entity.shipmobie;
                order.shipaddress = entity.shipaddress;
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
                var order = db.orders.Find(id);
                db.orders.Remove(order);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<order> ListAll()
        {
            return db.orders.ToList();
        }
    }
}
