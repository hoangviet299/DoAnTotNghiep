using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class OrderDetailDao
    {
        ShopVanPhongPhamDBContext db = null;
        public OrderDetailDao()
        {
            db = new ShopVanPhongPhamDBContext();
        }
        /*public bool Insert(orderDetail detail)
        {
            try
            {
                db.orderDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }*/
        public long Insert(orderDetail entity)
        {
            db.orderDetails.Add(entity);
            db.SaveChanges();
            return entity.id_orderDetail;
        }
        /*public IEnumerable<orderDetail> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<orderDetail> model = db.orderDetails;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.name.Contains(searchString) || x.name.Contains(searchString));

            }
            return model.OrderByDescending(x => x.created_at).ToPagedList(page, pageSize);
        }*/
        /*public orderDetail GetbyID(string orderDetailName)
        {
            return db.orderDetails.SingleOrDefault(x => x.name == orderDetailName);
        }*/

        public orderDetail ViewDetail(long id)
        {
            return db.orderDetails.Find(id);
        }
        /*public bool Update(orderDetail entity)
        {
            try
            {
                var orderDetail = db.orderDetail.Find(entity.id_new);
                orderDetail.id_new = entity.id_new;
                orderDetail.name = entity.name;
                orderDetail.description = entity.description;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }*/
        public bool Delete(int id)
        {
            try
            {
                var orderDetail = db.orderDetails.Find(id);
                db.orderDetails.Remove(orderDetail);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<orderDetail> ListAll()
        {
            return db.orderDetails.ToList();
        }
        public orderDetail ViewDetail(int id)
        {
            return db.orderDetails.Find(id);
        }
    }
}
