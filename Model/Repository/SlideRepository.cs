using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class SlideRepository
    {
        PetStoreDbContext db = null;

        public SlideRepository()
        {
            db = new PetStoreDbContext();
        }

        public int InsertOrUpdate(Slide entity)
        {
            var x = entity.Slide_ID;
            if (entity.Slide_ID <= 0)
            {
                db.Slides.Add(entity);
                db.SaveChanges();
            }
            else
            {
                var slide = db.Slides.Find(entity.Slide_ID);
                slide.TieuDe = entity.TieuDe;
                slide.Link_Image = entity.Link_Image;
                slide.ThuTu = entity.ThuTu;
                slide.ChiTiet = entity.ChiTiet;
                db.SaveChanges();
            }
            return entity.Slide_ID;
        }
        public IEnumerable<Slide> ListAllPaging(String searchString, int page, int pageSize)
        {
            IQueryable<Slide> model = db.Slides;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TieuDe.Contains(searchString));
            }
            return model.OrderByDescending(x=> x.ThuTu).ThenBy(x => x.TieuDe).ToPagedList(page, pageSize);
        }
        public void Delete(int id)
        {
            Slide Slide = db.Slides.SingleOrDefault(x => x.Slide_ID == id);
            db.Slides.Remove(Slide);
            db.SaveChanges();
        }

        public Slide GetByID(int id)
        {
            return (db.Slides.SingleOrDefault(x => x.Slide_ID == id));
        }
        public List<Slide> ListAll()
        {
            return db.Slides.OrderBy(x => x.ThuTu).ThenBy(x => x.TieuDe).ToList();
        }
    }
}
