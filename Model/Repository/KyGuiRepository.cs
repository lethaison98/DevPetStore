using Model.Attributes;
using Model.Dto;
using Model.EF;
using Model.Enums;
using PagedList;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class KyGuiRepository
    {
        PetStoreDbContext db = null;
        public KyGuiRepository()
        {
            db = new PetStoreDbContext();
        }
        public KyGuiDto ConvertToLichHenDto(LichHen entity)
        {
            var data = new KyGuiDto();
            data.ID_LichHen = entity.LichHen_ID;
            data.ID_KhachHang = entity.ID_KhachHang;
            data.TenKhachHang = entity.TenNguoiHen;
            data.CreateDate = entity.CreateDate.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            data.SoDienThoai = entity.SoDienThoai;
            data.TenTrangThaiLichHen = GetEnum.GetText(GetEnum.GetByCode(entity.TrangThaiLichHen));
            data.GiongThuCung = entity.GiongThuCung;
            data.NgayHen = entity.NgayHen;
            data.GioHen = entity.GioHen;
            return data;
        }
        public KyGuiChiTietDto ConvertToChiTietDto (LichKyGui entity)
        {
            var data = new KyGuiChiTietDto();
            data.TenKhachHang = entity.LichHen.TenNguoiHen;
            data.SoDienThoai = entity.LichHen.SoDienThoai;
            data.Email = entity.LichHen.Email;
            data.TenTrangThaiLichHen = GetEnum.GetText(GetEnum.GetByCode(entity.LichHen.TrangThaiLichHen));
            data.CreateDate = entity.LichHen.CreateDate.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            data.TenPet = entity.TenPet;
            data.GiongThuCung = entity.LichHen.GiongThuCung;
            data.SoThang = entity.SoThang;
            data.CanNang = entity.CanNang;
            data.GioiTinh = entity.GioiTinh;
            data.TuGio = entity.TuGio;
            data.TuNgay = entity.TuNgay;
            data.DenGio = entity.DenGio;
            data.DenNgay = entity.DenNgay;
            data.DonTraTaiNha = entity.DonTraTaiNha ? "Có" : "Không";
            data.DiaChiDonTra = entity.DiaChiDonTra;
            data.TenLoaiKyGui = entity.TenLoaiKyGui;
            data.GhiChu = entity.LichHen.GhiChu;
            return data;
        }
        public int Insert(LichKyGui kyGui)
        {
            db.LichKyGuis.Add(kyGui);
            db.SaveChanges();
            return kyGui.ID_LichKyGui;
        }
        public IEnumerable<KyGuiDto> LayDanhSachKyGuiTheoTrangThai(String searchString, int page, int pageSize, TrangThaiLichHenEnum trangThaiEnum)
        {
            IEnumerable<KyGuiDto> returnData;
            IEnumerable<LichHen> data;
            IQueryable<LichHen> model = db.LichHens;
            model = model.Where(x => x.LoaiLichHen == 2);
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenNguoiHen.Contains(searchString) || x.SoDienThoai.Contains(searchString));
            }
            var trangThaiKyGui = GetLichHenEnum.GetCode(trangThaiEnum);
            model = model.Where(x => x.TrangThaiLichHen == trangThaiKyGui);
            data = model.OrderByDescending(x => x.CreateDate);
            returnData = data.Select(x => new KyGuiDto 
            {
                ID_LichHen = x.LichHen_ID,
                ID_KhachHang = x.ID_KhachHang,
                TenKhachHang = x.TenNguoiHen,
                CreateDate = x.CreateDate.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                SoDienThoai = x.SoDienThoai,
                TenTrangThaiLichHen = GetEnum.GetText(GetEnum.GetByCode(x.TrangThaiLichHen)),
                GiongThuCung = x.GiongThuCung,
                NgayHen = x.NgayHen,
                GioHen = x.GioHen
            });
            return returnData.ToPagedList(page, pageSize);
        }

        public KyGuiChiTietDto GetKyGuiById(int id)
        {
            return ConvertToChiTietDto(db.LichKyGuis.SingleOrDefault(x => x.ID_LichHen == id));
        }
        public List<KyGuiDto> LayDanhSachKyGuiByKhachHangId(int id)
        {
            List<KyGuiDto> returnData;
            returnData = db.LichHens.Where(x => x.ID_KhachHang == id && x.LoaiLichHen == 2).OrderByDescending(x => x.CreateDate).Select(ConvertToLichHenDto).ToList();
            return returnData;
        }
        public bool XacNhan(int id)
        {
            var entity = db.LichHens.SingleOrDefault(x => x.LichHen_ID == id);
            if (entity.TrangThaiLichHen == GetLichHenEnum.GetCode(TrangThaiLichHenEnum.ChuaXacNhan))
            {
                entity.TrangThaiLichHen = GetLichHenEnum.GetCode(TrangThaiLichHenEnum.DaXacNhan);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
        public bool DangKyGui(int id)
        {
            var entity = db.LichHens.SingleOrDefault(x => x.LichHen_ID == id);
            if ((entity.TrangThaiLichHen == GetLichHenEnum.GetCode(TrangThaiLichHenEnum.DaXacNhan)))
            {
                entity.TrangThaiLichHen = GetLichHenEnum.GetCode(TrangThaiLichHenEnum.DangKyGui);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
        public bool TuChoi(int id)
        {
            var entity = db.LichHens.SingleOrDefault(x => x.LichHen_ID == id);
            if (entity.TrangThaiLichHen == GetLichHenEnum.GetCode(TrangThaiLichHenEnum.ChuaXacNhan) || (entity.TrangThaiLichHen == GetLichHenEnum.GetCode(TrangThaiLichHenEnum.DaXacNhan)))
            {
                entity.TrangThaiLichHen = GetLichHenEnum.GetCode(TrangThaiLichHenEnum.DaHuy);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
        public bool HoanThanh(int id)
        {
            var entity = db.LichHens.SingleOrDefault(x => x.LichHen_ID == id);
            if ((entity.TrangThaiLichHen == GetLichHenEnum.GetCode(TrangThaiLichHenEnum.DangKyGui)))
            {
                entity.TrangThaiLichHen = GetLichHenEnum.GetCode(TrangThaiLichHenEnum.DaHoanThanh);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
