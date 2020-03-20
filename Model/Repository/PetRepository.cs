using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class PetRepository
    {
        PetStoreDbContext db = null;

        public PetRepository()
        {
            db = new PetStoreDbContext();
        }

        public int InsertOrUpdate(Pet entity)
        {
            var x = entity.ID_Pet;
            if (entity.ID_Pet <= 0)
            {
                db.Pets.Add(entity);
                db.SaveChanges();
            }
            else
            {
                var pet = db.Pets.Find(entity.ID_Pet);
                pet.Ten_Pet = entity.Ten_Pet;
                pet.ID_GiongPet = entity.ID_GiongPet;
                pet.MoTa = entity.MoTa;
                pet.Image = entity.Image;
                pet.MauLong = entity.MauLong;
                pet.GioiTinh = entity.GioiTinh;
                pet.ChiTiet = entity.ChiTiet;
                pet.MetaTitle = entity.MetaTitle;
                pet.Status = entity.Status;
                pet.GiaTien = entity.GiaTien;
                db.SaveChanges();
            }
            return entity.ID_Pet;
        }
        public IEnumerable<Pet> ListAllPaging(String searchString, int page, int pageSize)
        {
            IQueryable<Pet> model = db.Pets;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Ten_Pet.Contains(searchString));
            }
            return model.OrderByDescending(x => x.Ten_Pet).ToPagedList(page, pageSize);
        }
        public void Delete(int id)
        {
            Pet pet = db.Pets.SingleOrDefault(x => x.ID_Pet == id);
            db.Pets.Remove(pet);
            db.SaveChanges();
        }

        public Pet GetByID(int id)
        {
            return (db.Pets.SingleOrDefault(x => x.ID_Pet == id));
        }
    }
}
