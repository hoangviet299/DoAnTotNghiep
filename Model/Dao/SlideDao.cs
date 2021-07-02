using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class SlideDao
    {
        ShopVanPhongPhamDBContext db = null;
        public SlideDao()
        {
            db = new ShopVanPhongPhamDBContext();
        }
        public List<Slide> ListAll()
        {
            return db.Slides.Where(x => x.status == true).OrderBy(y=>y.displayorder).ToList();
        }
        public int Insert(Slide Slide)
        {
            db.Slides.Add(Slide);
            db.SaveChanges();
            return Slide.id_slide;
        }
        public IEnumerable<Slide> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Slide> model = db.Slides;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.link.Contains(searchString) || x.link.Contains(searchString));

            }
            return model.OrderByDescending(x => x.created_at).ToPagedList(page, pageSize);
        }
        public Slide GetbyID(string SlideName)
        {
            return db.Slides.SingleOrDefault(x => x.link == SlideName);
        }

        public Slide ViewDetail(long id)
        {
            return db.Slides.Find(id);
        }
        public bool Update(Slide entity)
        {
            try
            {
                var Slide = db.Slides.Find(entity.id_slide);
                Slide.id_slide = entity.id_slide;
                Slide.images = entity.images;
                Slide.displayorder = entity.displayorder;
                Slide.description = entity.description;
                Slide.link = entity.link;
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
                var Slide = db.Slides.Find(id);
                db.Slides.Remove(Slide);
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
