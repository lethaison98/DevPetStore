using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class DonHangDto
    {
        public int ID_DonHang { get; set; }
        public int? ID_KhachHang { get; set; }

        public string CreateDate { get; set; }

        public string ConfirmDate { get; set; }

        public string ShipDate { get; set; }

        public string ShipName { get; set; }

        public string ShipMobile { get; set; }

        public string ShipAddress { get; set; }

        public decimal TongTien { get; set; }
        public int TrangThaiDatHang { get; set; }
        public string TenTrangThaiDatHang { get; set; }
        public int TrangThaiGiaoHang { get; set; }
        public string TenTrangThaiGiaoHang { get; set; }
        public int TrangThaiDonHang { get; set; }
        public string TenTrangThaiDonHang { get; set; }
        public string LyDoHuy { get; set; }
        public List<DonHangDetailDto> DanhSachDonHangChiTiet { get; set; }
    }
    public class DonHangDetailDto{
        public int ID_DonHangDetail { get; set; }
        public int ID_DonHang { get; set; }
        public int ID_Item { get; set; }
        public string ImgLink { get; set; }
        public string TenItem { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
