using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class BaiVietRepository
    {
        PetStoreDbContext db = null;

        public BaiVietRepository()
        {
            db = new PetStoreDbContext();
        }

        public int InsertOrUpdate(BaiViet entity)
        {
            if (entity.ID_BaiViet <= 0)
            {
                entity.CreateDate = DateTime.Now;
                db.BaiViets.Add(entity);
                db.SaveChanges();
            }
            else
            {
                var baiViet = db.BaiViets.Find(entity.ID_BaiViet);
                baiViet.Title = entity.Title;
                baiViet.Para1 = entity.Para1;
                baiViet.Para2 = entity.Para2;
                baiViet.Para3 = entity.Para3;
                baiViet.ImageLink1 = entity.ImageLink1;
                baiViet.ImgLink2 = entity.ImgLink2;
                baiViet.ImgLink3 = entity.ImgLink3;
                baiViet.Metatitle = entity.Metatitle;
                db.SaveChanges();
            }
            return entity.ID_BaiViet;
        }
        public IEnumerable<BaiViet> ListAllPaging(String searchString, int page, int pageSize)
        {
            IQueryable<BaiViet> model = db.BaiViets;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Title.Contains(searchString));
            }
            return model.OrderByDescending(x => x.Title).ToPagedList(page, pageSize);
        }
        public void Delete(int id)
        {
            BaiViet BaiViet = db.BaiViets.SingleOrDefault(x => x.ID_BaiViet == id);
            db.BaiViets.Remove(BaiViet);
            db.SaveChanges();
        }

        public BaiViet GetByID(int id)
        {
            return (db.BaiViets.SingleOrDefault(x => x.ID_BaiViet == id));
        }
        public List<BaiViet> ListAll()
        {
            return db.BaiViets.ToList();
        }
        public BaiViet GetBaiViet(String Metatitle)
        {
            return db.BaiViets.SingleOrDefault(x => x.Metatitle == Metatitle);
        }
    }
}
