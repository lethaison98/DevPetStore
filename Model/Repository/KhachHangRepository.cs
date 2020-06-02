using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class KhachHangRepository
    {
        PetStoreDbContext db = null;
        public KhachHangRepository()
        {
            db = new PetStoreDbContext();
        }
        public int InsertOrUpdate(KhachHang entity)
        {
            if (entity.ID_KhachHang <= 0)
            {
                db.KhachHangs.Add(entity);
                db.SaveChanges();
            }
            else
            {
                var khachHang = db.KhachHangs.FirstOrDefault(x => x.ID_User == entity.ID_User);
                khachHang.DiaChi = entity.DiaChi;
                khachHang.Ten = entity.Ten;
                khachHang.Email = entity.Email;
                khachHang.SoDienThoai = entity.SoDienThoai;
                khachHang.NgaySinh = entity.NgaySinh;
                khachHang.GioiTinh = entity.GioiTinh;
                db.SaveChanges();
            }
            return entity.ID_User;

        }
        public KhachHang GetByKhachHangId(int id)
        {
            return db.KhachHangs.FirstOrDefault(x => x.ID_KhachHang == id);
        }
        public KhachHang GetByUserId(int id)
        {
            return db.KhachHangs.FirstOrDefault(x => x.ID_User == id);
        }

    }
}
