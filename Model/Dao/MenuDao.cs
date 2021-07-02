using System;
using Model.EF;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
    public class MenuDao
    {
        ShopVanPhongPhamDBContext db = null;
        public MenuDao()
        {
            db = new ShopVanPhongPhamDBContext();
        }
        public List<Menu> ListByGroupId(int groupId)
        {
            return db.Menus.Where(x => x.id_menutype == groupId && x.status == true).OrderBy(x=>x.displayorđer).ToList();
        }
        public int Insert(Menu Menu)
        {
            db.Menus.Add(Menu);
            db.SaveChanges();
            return Menu.id_menu;
        }
        public IEnumerable<Menu> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Menu> model = db.Menus;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.text.Contains(searchString) || x.text.Contains(searchString));

            }
            return model.OrderByDescending(x => x.displayorđer).ToPagedList(page, pageSize);
        }
        public Menu GetbyID(string MenuName)
        {
            return db.Menus.SingleOrDefault(x => x.text == MenuName);
        }

        public Menu ViewDetail(long id)
        {
            return db.Menus.Find(id);
        }
        public bool Update(Menu entity)
        {
            try
            {
                var Menu = db.Menus.Find(entity.id_menu);
                Menu.id_menu = entity.id_menu;
                Menu.text = entity.text;
                Menu.link = entity.link;
                Menu.displayorđer = entity.displayorđer;
                Menu.id_menutype = entity.id_menutype;
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
                var Menu = db.Menus.Find(id);
                db.Menus.Remove(Menu);
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
