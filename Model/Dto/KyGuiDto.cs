using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class KyGuiDto
    {
        public int ID_LichHen { get; set; }
        public int ID_KhachHang { get; set; }
        [StringLength(50)]
        public string TenKhachHang { get; set; }
        [StringLength(20)]
        public string SoDienThoai { get; set; }
        public string TenTrangThaiLichHen { get; set; }
        public int TrangThaiLichHen { get; set; }
        public string CreateDate { get; set; }
        public string NgayHen { get; set; }
        public string GioHen { get; set; }
        public string GiongThuCung { get; set; }

    }
    public class KyGuiChiTietDto
    {
        public int ID_LichKyGui { get; set; }
        public int ID_LichHen { get; set; }
        public int ID_KhachHang { get; set; }

        [StringLength(50)]
        public string TenKhachHang { get; set; }

        [StringLength(20)]
        public string SoDienThoai { get; set; }

        [StringLength(30)]
        public string Email { get; set; }
        public string CreateDate { get; set; }
        public int TrangThaiLichHen { get; set; }
        public string TenTrangThaiLichHen { get; set; }
        public string TuNgay { get; set; }
        public string TuGio { get; set; }
        public string DenNgay { get; set; }
        public string DenGio { get; set; }
        public string TenPet { get; set; }
        public string LoaiThuCung { get; set; }
        public string GiongThuCung { get; set; }
        public int SoThang { get; set; }
        public decimal CanNang { get; set; }
        public string GioiTinh { get; set; }
        public string TinhTrangSucKhoe { get; set; }
        public string DonTraTaiNha { get; set; }
        public string DiaChiDonTra { get; set; }
        public string TenLoaiKyGui { get; set; }
        [StringLength(250)]
        public string GhiChu { get; set; }
        public List<CapNhatKyGuiDto> DanhSachCapNhat { get; set; }
    }
    public class CapNhatKyGuiDto
    {
        public int ID_CapNhatKyGui { get; set; }
        public int ID_LichKyGui { get; set; }
        public string ThoiGianCapNhat { get; set; }
        public string imgLink1 { get; set; }
        public string imgLink2 { get; set; }
        public string imgLink3 { get; set; }
        public string TinhTrangThuCung { get; set; }
        public string NoiDungCapNhat { get; set; }
    }
}
