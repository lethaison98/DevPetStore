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
    public class LichHenRepository
    {
        PetStoreDbContext db = null;
        public LichHenRepository()
        {
            db = new PetStoreDbContext();
        }
        public LichHenDto ConvertToLichHenDto(LichHen entity)
        {
            var data = new LichHenDto();
            data.ID_LichHen = entity.ID_LichHen;
            data.ID_KhachHang = entity.ID_KhachHang;
            data.TenKhachHang = entity.TenNguoiHen;
            data.CreateDate = entity.CreateDate.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            data.SoDienThoai = entity.SoDienThoai;
            data.Email = entity.Email;
            data.TrangThaiLichHen = entity.TrangThaiLichHen;
            data.TenTrangThaiLichHen = GetLichHenEnum.GetText(GetLichHenEnum.GetByCode(entity.TrangThaiLichHen));
            data.GiongThuCung = entity.GiongThuCung;
            data.NgayHen = entity.NgayHen;
            data.GioHen = entity.GioHen;
            data.DanhSachLichHenDetail = LayDanhSachLichHenChiTiet(data.ID_LichHen, 1, 10).ToList();
            return data;
        }
        public LichHenDetailDto ConvertToLichHenDetailDto (LichHenDetail entity)
        {
            var data = new LichHenDetailDto();
            data.ID_LichHenDetail = entity.ID_LichHenDetail;
            data.ID_LichHen = entity.ID_LichHen;
            data.TenDichVu = entity.DichVu.TenDichVu;
            data.DonGia = entity.DichVu.DonGia;
            data.DonViTinh = entity.DichVu.DonViTinh;
            return data;
        }
        public int Insert(LichHen lichHen)
        {
            lichHen.CreateDate = DateTime.Now;
            db.LichHens.Add(lichHen);
            db.SaveChanges();
            return lichHen.ID_LichHen;
        }
        public int InsertLichHenDetail(LichHenDetail lichHenDetail)
        {
            db.LichHenDetails.Add(lichHenDetail);
            db.SaveChanges();
            return lichHenDetail.ID_LichHenDetail;
        }
        public int InsertLichKyGui(LichKyGui lichKyGui)
        {
            db.LichKyGuis.Add(lichKyGui);
            db.SaveChanges();
            return lichKyGui.ID_LichKyGui;
        }
        public IEnumerable<LichHenDto> LayDanhSachLichHenTheoTrangThai(String searchString, int page, int pageSize, TrangThaiLichHenEnum trangThaiEnum)
        {
            IEnumerable<LichHenDto> returnData;
            IEnumerable<LichHen> data;
            IQueryable<LichHen> model = db.LichHens;
            model = model.Where(x => x.LoaiLichHen == 1);
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenNguoiHen.Contains(searchString) || x.SoDienThoai.Contains(searchString));
            }
            var trangThaiKyGui = GetLichHenEnum.GetCode(trangThaiEnum);
            model = model.Where(x => x.TrangThaiLichHen == trangThaiKyGui);
            data = model.OrderByDescending(x => x.CreateDate);
            returnData = data.Select(x => new LichHenDto
            {
                ID_LichHen = x.ID_LichHen,
                ID_KhachHang = x.ID_KhachHang,
                TenKhachHang = x.TenNguoiHen,
                CreateDate = x.CreateDate.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                SoDienThoai = x.SoDienThoai,
                Email = x.Email,
                TrangThaiLichHen = x.TrangThaiLichHen,
                TenTrangThaiLichHen = GetLichHenEnum.GetText(GetLichHenEnum.GetByCode(x.TrangThaiLichHen)),
                GiongThuCung = x.GiongThuCung,
                NgayHen = x.NgayHen,
                GioHen = x.GioHen
            });
            return returnData.ToPagedList(page, pageSize);
        }

        public LichHenDto GetLichHenById(int id)
        {
            return ConvertToLichHenDto(db.LichHens.SingleOrDefault(x => x.ID_LichHen == id));
        }
        public IEnumerable<LichHenDetailDto> LayDanhSachLichHenChiTiet(int ID_LichHen, int page, int pageSize)
        {
            IEnumerable<LichHenDetailDto> returnedData;
            IEnumerable<LichHenDetail> data;
            IQueryable<LichHenDetail> model = db.LichHenDetails;
            model = model.Where(x => x.ID_LichHen == ID_LichHen);
            data = model.OrderByDescending(x => x.ID_LichHenDetail);
            returnedData = data.Select(x => ConvertToLichHenDetailDto(x));
            return returnedData.ToPagedList(page, pageSize);
        }
        public List<LichHenDto> LayDanhSachLichHenByKhachHangId(int id)
        {
            List<LichHenDto> returnData;
            returnData = db.LichHens.Where(x => x.ID_KhachHang == id && x.LoaiLichHen == 1).OrderByDescending(x => x.CreateDate).Select(ConvertToLichHenDto).ToList();
            return returnData;
        }
        public bool XacNhan(int id)
        {
            var entity = db.LichHens.SingleOrDefault(x => x.ID_LichHen == id);
            if (entity.TrangThaiLichHen == GetLichHenEnum.GetCode(TrangThaiLichHenEnum.ChuaXacNhan))
            {
                entity.TrangThaiLichHen = GetLichHenEnum.GetCode(TrangThaiLichHenEnum.DaXacNhan);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
        public bool TuChoi(int id)
        {
            var entity = db.LichHens.SingleOrDefault(x => x.ID_LichHen == id);
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
            var entity = db.LichHens.SingleOrDefault(x => x.ID_LichHen == id);
            if ((entity.TrangThaiLichHen == GetLichHenEnum.GetCode(TrangThaiLichHenEnum.DaXacNhan)))
            {
                entity.TrangThaiLichHen = GetLichHenEnum.GetCode(TrangThaiLichHenEnum.DaHoanThanh);
                db.SaveChanges();
                return true;
            }
            else return false;
        }


    }
}
