using Model.Dto;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class HotDealRepository
    {
        PetStoreDbContext db = null;

        public HotDealRepository()
        {
            db = new PetStoreDbContext();
        }

        public HotDealDto ConvertToDto (HotDeal entity)
        {
            var data = new HotDealDto();
            data.ID_HotDeal = entity.ID_HotDeal;
            data.ID_Item = entity.ID_Item;
            data.GiaKhuyenMai = entity.GiaKhuyenMai;
            data.ID_GiongPet = entity.Pet.ID_GiongPet;
            data.Ten_Pet = entity.Pet.Ten_Pet;
            data.Image = entity.Pet.Image;
            data.Image2 = entity.Pet.Image2;
            data.Image3 = entity.Pet.Image3;
            data.MauLong = entity.Pet.MauLong;
            data.MetaTitle = entity.Pet.MetaTitle;
            data.GiaTien = entity.Pet.GiaTien;
            data.GioiTinh = entity.Pet.GioiTinh;
            data.MoTa = entity.Pet.MoTa;
            data.NguonGoc = entity.Pet.NguonGoc;
            data.ChiTiet = entity.Pet.ChiTiet;
            return data;
        }
        public int InsertOrUpdate(HotDeal entity)
        {
            if (entity.ID_HotDeal <= 0)
            {
                db.HotDeals.Add(entity);
                db.SaveChanges();
            }
            else
            {
                var hotDeal = db.HotDeals.Find(entity.ID_HotDeal);
                hotDeal.ID_Item = entity.ID_Item;
                hotDeal.GiaKhuyenMai = entity.GiaKhuyenMai;
                db.SaveChanges();
            }
            return entity.ID_HotDeal;
        }
        public void Delete(int id)
        {
            HotDeal HotDeal = db.HotDeals.SingleOrDefault(x => x.ID_HotDeal == id);
            db.HotDeals.Remove(HotDeal);
            db.SaveChanges();
        }

        public HotDeal GetByID(int id)
        {
            return (db.HotDeals.SingleOrDefault(x => x.ID_HotDeal == id));
        }
        public List<HotDealDto> ListAll()
        {
            var list = db.HotDeals.ToList();
            var returnResult = new List<HotDealDto>();
            foreach(var item in list)
            {
                returnResult.Add(ConvertToDto(item));
            }
            return returnResult;
        }
        public List<HotDeal> ListAllEntity()
        {
            return db.HotDeals.ToList();
        }
        public HotDeal GetHotDeal(int id)
        {
            return db.HotDeals.SingleOrDefault(x => x.ID_HotDeal == id);
        }

    }
}
