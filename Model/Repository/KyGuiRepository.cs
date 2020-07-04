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
            data.ID_LichHen = entity.ID_LichHen;
            data.ID_KhachHang = entity.ID_KhachHang;
            data.TongTien = entity.TongTien;
            data.TenKhachHang = entity.TenNguoiHen;
            data.CreateDate = entity.CreateDate.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            data.SoDienThoai = entity.SoDienThoai;
            data.TrangThaiLichHen = entity.TrangThaiLichHen;
            data.TenTrangThaiLichHen = GetLichHenEnum.GetText(GetLichHenEnum.GetByCode(entity.TrangThaiLichHen));
            data.GiongThuCung = entity.GiongThuCung;
            data.NgayHen = entity.NgayHen;
            data.GioHen = entity.GioHen;
            data.LyDoHuy = entity.LyDoHuy;
            return data;
        }
        public KyGuiChiTietDto ConvertToChiTietDto(LichKyGui entity)
        {
            var data = new KyGuiChiTietDto();
            data.ID_LichKyGui = entity.ID_LichKyGui;
            data.ID_LichHen = entity.ID_LichHen;
            data.ID_KhachHang = entity.LichHen.ID_KhachHang;
            data.ID_DichVuKyGui = entity.ID_DichVuKyGui;
            data.TongTien = entity.LichHen.TongTien;
            data.TenKhachHang = entity.LichHen.TenNguoiHen;
            data.SoDienThoai = entity.LichHen.SoDienThoai;
            data.Email = entity.LichHen.Email;
            data.TrangThaiLichHen = entity.LichHen.TrangThaiLichHen; 
            data.TenTrangThaiLichHen = GetLichHenEnum.GetText(GetLichHenEnum.GetByCode(entity.LichHen.TrangThaiLichHen));
            data.CreateDate = entity.LichHen.CreateDate.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            data.TenPet = entity.TenPet;
            data.GiongThuCung = entity.LichHen.GiongThuCung;
            data.LoaiThuCung = entity.LichHen.LoaiThuCung;
            data.SoThang = entity.SoThang;
            data.GioiTinh = entity.GioiTinh;
            data.TuGio = entity.TuGio;
            data.TuNgay = entity.TuNgay;
            data.DenGio = entity.DenGio;
            data.DenNgay = entity.DenNgay;
            data.DonTraTaiNha = entity.DonTraTaiNha ? "Có" : "Không";
            data.DiaChiDonTra = entity.DiaChiDonTra;
            data.TenLoaiKyGui = entity.TenLoaiKyGui;
            data.GhiChu = entity.LichHen.GhiChu;
            data.LyDoHuy = entity.LichHen.LyDoHuy;
            data.DanhSachCapNhat = LayThongTinKyGui(entity.ID_LichHen);
            return data;
        }

        public CapNhatKyGuiDto ConvertToCapNhatKyGuiDto(CapNhatKyGui entity)
        {
            var data = new CapNhatKyGuiDto();
            data.ID_CapNhatKyGui = entity.ID_CapNhatKyGui;
            data.ID_LichKyGui = entity.ID_LichKyGui;
            data.imgLink1 = entity.ImgLink1;
            data.imgLink2 = entity.ImgLink2;
            data.imgLink3 = entity.ImgLink3;
            data.NoiDungCapNhat = entity.NoiDungCapNhat;
            data.TinhTrangThuCung = entity.TinhTrangThuCung;
            data.ThoiGianCapNhat = entity.ThoiGianCapNhat.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
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
                ID_LichHen = x.ID_LichHen,
                ID_KhachHang = x.ID_KhachHang,
                TenKhachHang = x.TenNguoiHen,
                CreateDate = x.CreateDate.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                SoDienThoai = x.SoDienThoai,
                TrangThaiLichHen = x.TrangThaiLichHen,
                TongTien = x.TongTien,
                TenTrangThaiLichHen = GetLichHenEnum.GetText(GetLichHenEnum.GetByCode(x.TrangThaiLichHen)),
                GiongThuCung = x.GiongThuCung,
                NgayHen = x.NgayHen,
                LyDoHuy = x.LyDoHuy,
                GioHen = x.GioHen
            });
            return returnData.ToPagedList(page, pageSize);
        }

        public KyGuiChiTietDto GetKyGuiChiTietDtoByLichHenId(int id)
        {
            return ConvertToChiTietDto(db.LichKyGuis.SingleOrDefault(x => x.ID_LichHen == id));
        }
        public LichHen GetLichHenByID_LichKyGui(int id)
        {
            var ID_LichHen = db.LichKyGuis.SingleOrDefault(x => x.ID_LichKyGui == id).ID_LichHen;
            return db.LichHens.SingleOrDefault(x => x.ID_LichHen == ID_LichHen);
        }
        public List<KyGuiChiTietDto> LayDanhSachKyGuiByKhachHangId(int id)
        {
            List<KyGuiChiTietDto> returnData;
            returnData = db.LichKyGuis.Where(x => x.LichHen.ID_KhachHang == id && x.LichHen.LoaiLichHen == 2).OrderByDescending(x => x.LichHen.CreateDate).Select(ConvertToChiTietDto).ToList();
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
        public bool DangKyGui(int id)
        {
            var entity = db.LichHens.SingleOrDefault(x => x.ID_LichHen == id);
            if ((entity.TrangThaiLichHen == GetLichHenEnum.GetCode(TrangThaiLichHenEnum.DaXacNhan)))
            {
                entity.TrangThaiLichHen = GetLichHenEnum.GetCode(TrangThaiLichHenEnum.DangKyGui);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
        public bool TuChoi(int id, string lydo)
        {
            var entity = db.LichHens.SingleOrDefault(x => x.ID_LichHen == id);
            if (entity.TrangThaiLichHen == GetLichHenEnum.GetCode(TrangThaiLichHenEnum.ChuaXacNhan) || (entity.TrangThaiLichHen == GetLichHenEnum.GetCode(TrangThaiLichHenEnum.DaXacNhan)))
            {
                entity.TrangThaiLichHen = GetLichHenEnum.GetCode(TrangThaiLichHenEnum.DaHuy);
                entity.LyDoHuy = lydo;
                db.SaveChanges();
                return true;
            }
            else return false;
        }
        public bool HoanThanh(int id)
        {
            var entity = db.LichHens.SingleOrDefault(x => x.ID_LichHen == id);
            if ((entity.TrangThaiLichHen == GetLichHenEnum.GetCode(TrangThaiLichHenEnum.DangKyGui)))
            {
                entity.TrangThaiLichHen = GetLichHenEnum.GetCode(TrangThaiLichHenEnum.DaHoanThanh);
                db.SaveChanges();
                return true;
            }
            else return false;
        }

        public int CapNhatKyGui (CapNhatKyGui entity)
        {
            db.CapNhatKyGuis.Add(entity);
            entity.ThoiGianCapNhat = DateTime.Now;
            db.SaveChanges();
            return entity.ID_LichKyGui;
        }
        public List<CapNhatKyGuiDto> LayThongTinKyGui (int id)
        {
            return db.CapNhatKyGuis.Where(x => x.LichKyGui.LichHen.ID_LichHen == id).Select(ConvertToCapNhatKyGuiDto).ToList();
        }
        public decimal CapNhatChiPhi(string loaiPet, decimal canNang, int ID_DichVuKyGui, string fromDate, string fromHour,string toDate, string toHour)
        {
            decimal donGia = 0;
            decimal thanhTien = 0;
            if (loaiPet == "Chó")
            {
                if (canNang < 10)
                {
                    donGia = db.DichVuKyGuis.SingleOrDefault(x => x.ID_DichVuKyGui == ID_DichVuKyGui).Cho_0_10;
                }
                else if (canNang >= 10 && canNang < 15)
                {
                    donGia = db.DichVuKyGuis.SingleOrDefault(x => x.ID_DichVuKyGui == ID_DichVuKyGui).Cho_10_15;
                }
                else if (canNang >= 15 && canNang < 20)
                {
                    donGia = db.DichVuKyGuis.SingleOrDefault(x => x.ID_DichVuKyGui == ID_DichVuKyGui).Cho_15_20;
                }
                else if (canNang >= 20 && canNang < 25)
                {
                    donGia = db.DichVuKyGuis.SingleOrDefault(x => x.ID_DichVuKyGui == ID_DichVuKyGui).Cho_20_25;
                }
                else
                {
                    donGia = db.DichVuKyGuis.SingleOrDefault(x => x.ID_DichVuKyGui == ID_DichVuKyGui).Cho_over25;
                }
            }
            else if (loaiPet == "Mèo")
            {
                if (canNang < 2)
                {
                    donGia = db.DichVuKyGuis.SingleOrDefault(x => x.ID_DichVuKyGui == ID_DichVuKyGui).Meo_0_2;
                }
                else if (canNang >= 2 && canNang < 5)
                {
                    donGia = db.DichVuKyGuis.SingleOrDefault(x => x.ID_DichVuKyGui == ID_DichVuKyGui).Meo_2_5;
                }
                else if (canNang >= 5 && canNang < 8)
                {
                    donGia = db.DichVuKyGuis.SingleOrDefault(x => x.ID_DichVuKyGui == ID_DichVuKyGui).Meo_5_8;
                }
                else
                {
                    donGia = db.DichVuKyGuis.SingleOrDefault(x => x.ID_DichVuKyGui == ID_DichVuKyGui).Meo_over8;
                }
            }
            string from = fromDate + " " + fromHour;
            string to = toDate + " " + toHour;
            DateTime tuNgay = DateTime.ParseExact(from, "dd-MM-yyyy HH:mm", null);
            DateTime denNgay = DateTime.ParseExact(to, "dd-MM-yyyy HH:mm", null);
            var khoangThoiGian = denNgay - tuNgay;
            double soNgay = khoangThoiGian.Days;
            var soGio = khoangThoiGian.Hours;
            if(soGio > 12)
            {
                soNgay = soNgay + 1;
            }
            else
            if(soNgay >0 )
            {
                soNgay = soNgay + 0.5;
            }
            thanhTien = (decimal)soNgay * donGia;
            return thanhTien;
        }
    }
}
