using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class DichVuChamSocRepository
    {
        PetStoreDbContext db = null;

        public DichVuChamSocRepository()
        {
            db = new PetStoreDbContext();
        }
        public List<DichVuChamSoc> ListAll()
        {
            return db.DichVuChamSocs.ToList();
        }
        public int InsertOrUpdate(DichVuChamSoc entity)
        {

            if (entity.ID_DichVuChamSoc <= 0)
            {
                db.DichVuChamSocs.Add(entity);
                db.SaveChanges();
            }
            else
            {
                var dichVu = db.DichVuChamSocs.FirstOrDefault(x => x.ID_DichVuChamSoc == entity.ID_DichVuChamSoc);
                dichVu.TenDichVuChamSoc = entity.TenDichVuChamSoc;
                dichVu.Meo_0_2 = entity.Meo_0_2;
                dichVu.Meo_2_5 = entity.Meo_2_5;
                dichVu.Meo_5_8 = entity.Meo_5_8;
                dichVu.Meo_over8 = entity.Meo_over8;
                dichVu.Cho_0_10 = entity.Cho_0_10;
                dichVu.Cho_10_15 = entity.Cho_10_15;
                dichVu.Cho_15_20 = entity.Cho_15_20;
                dichVu.Cho_20_25 = entity.Cho_20_25;
                dichVu.Cho_over25 = entity.Cho_over25;
                dichVu.DonViTinh = entity.DonViTinh;
                db.SaveChanges();
            }
            return entity.ID_DichVuChamSoc;

        }

        public void Delete(int id)
        {
            DichVuChamSoc dichVu = db.DichVuChamSocs.SingleOrDefault(x => x.ID_DichVuChamSoc == id);
            db.DichVuChamSocs.Remove(dichVu);
            db.SaveChanges();
        }
        public DichVuChamSoc GetByID(int id)
        {
            return (db.DichVuChamSocs.SingleOrDefault(x => x.ID_DichVuChamSoc == id));
        }
    }
    public class DichVuKyGuiRepository
    {
        PetStoreDbContext db = null;

        public DichVuKyGuiRepository()
        {
            db = new PetStoreDbContext();
        }
        public List<DichVuKyGui> ListAll()
        {
            return db.DichVuKyGuis.ToList();
        }
        public int InsertOrUpdate(DichVuKyGui entity)
        {

            if (entity.ID_DichVuKyGui <= 0)
            {
                db.DichVuKyGuis.Add(entity);
                db.SaveChanges();
            }
            else
            {
                var dichVu = db.DichVuKyGuis.FirstOrDefault(x => x.ID_DichVuKyGui == entity.ID_DichVuKyGui);
                dichVu.TenDichVuKyGui = entity.TenDichVuKyGui;
                dichVu.GioiThieuDichVu = entity.GioiThieuDichVu;
                dichVu.Meo_0_2 = entity.Meo_0_2;
                dichVu.Meo_2_5 = entity.Meo_2_5;
                dichVu.Meo_5_8 = entity.Meo_5_8;
                dichVu.Meo_over8 = entity.Meo_over8;
                dichVu.Cho_0_10 = entity.Cho_0_10;
                dichVu.Cho_10_15 = entity.Cho_10_15;
                dichVu.Cho_15_20 = entity.Cho_15_20;
                dichVu.Cho_20_25 = entity.Cho_20_25;
                dichVu.Cho_over25 = entity.Cho_over25;
                dichVu.DonViTinh = entity.DonViTinh;
                db.SaveChanges();
            }
            return entity.ID_DichVuKyGui;

        }

        public void Delete(int id)
        {
            DichVuKyGui dichVu = db.DichVuKyGuis.SingleOrDefault(x => x.ID_DichVuKyGui == id);
            db.DichVuKyGuis.Remove(dichVu);
            db.SaveChanges();
        }
        public DichVuKyGui GetByID(int id)
        {
            return (db.DichVuKyGuis.SingleOrDefault(x => x.ID_DichVuKyGui == id));
        }
    }
}
