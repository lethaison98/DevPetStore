using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class LichHenDto
    {
        public int ID_LichHen { get; set; }
        public int ID_KhachHang { get; set; }
        [StringLength(50)]
        public string TenKhachHang { get; set; }
        [StringLength(20)]
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string TenTrangThaiLichHen { get; set; }
        public int TrangThaiLichHen { get; set; }
        public string CreateDate { get; set; }
        public string NgayHen { get; set; }
        public string GioHen { get; set; }
        public string GiongThuCung { get; set; }
        public List<LichHenDetailDto> DanhSachLichHenDetail { get; set; }
    }
    public class LichHenDetailDto
    {
        public int ID_LichHenDetail { get; set; }
        public int ID_LichHen { get; set; }
        public string TenDichVu { get; set; }
        public decimal DonGia { get; set; }
        public string DonViTinh { get; set; }
    } 
}
