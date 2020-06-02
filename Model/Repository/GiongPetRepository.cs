using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class GiongPetRepository
    {
        PetStoreDbContext db = null;

        public GiongPetRepository()
        {
            db = new PetStoreDbContext();
        }

        public int InsertOrUpdate(GiongPet entity)
        {
            var x = entity.ID_GiongPet;
            if (entity.ID_GiongPet <= 0)
            {
                db.GiongPets.Add(entity);
                db.SaveChanges();
            }
            else
            {
                var giongPet = db.GiongPets.Find(entity.ID_GiongPet);
                giongPet.TenGiongPet = entity.TenGiongPet;
                giongPet.ID_DanhMuc = entity.ID_DanhMuc;
                giongPet.ImgNguonGoc = entity.ImgNguonGoc;
                giongPet.NguonGoc = entity.NguonGoc;
                giongPet.ImgDacDiem = entity.ImgDacDiem;
                giongPet.DacDiem = entity.DacDiem;
                giongPet.ImgLyDoNuoi = entity.ImgLyDoNuoi;
                giongPet.LyDoNuoi = entity.LyDoNuoi;
                giongPet.MetaTitle = entity.MetaTitle;
                db.SaveChanges();
            }
            return entity.ID_GiongPet;
        }
        public IEnumerable<GiongPet> ListAllPaging(String searchString, int page, int pageSize)
        {
            IQueryable<GiongPet> model = db.GiongPets;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenGiongPet.Contains(searchString));
            }
            return model.OrderByDescending(x => x.TenGiongPet).ToPagedList(page, pageSize);
        }
        public void Delete(int id)
        {
            GiongPet giongPet = db.GiongPets.SingleOrDefault(x => x.ID_GiongPet == id);
            db.GiongPets.Remove(giongPet);
            db.SaveChanges();
        }

        public GiongPet GetByID(int id)
        {
            return (db.GiongPets.SingleOrDefault(x => x.ID_GiongPet == id));
        }
        public List<GiongPet> ListAll()
        {
            return db.GiongPets.ToList();
        }
        public GiongPet GetGiongPet(String Metatitle)
        {
            return db.GiongPets.SingleOrDefault(x => x.MetaTitle == Metatitle);
        }
    }
}
