using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    public class KyGuiModel
    {
        public int ID_LichKyGui { get; set; }
        public int ID_KhachHang { get; set; }
        public int? ID_GiongPet { get; set; }

        [StringLength(50)]
        public string TenKhachHang { get; set; }

        [StringLength(20)]
        public string SoDienThoai { get; set; }

        [StringLength(30)]
        public string Email { get; set; }
        public string NgayHen { get; set; }
        public string GioHen { get; set; }
        public string TuNgay { get; set; }
        public string TuGio { get; set; }
        public string DenNgay { get; set; }
        public string DenGio { get; set; }
        public string TenPet { get; set; }
        public int SoThang { get; set; }
        public decimal CanNang { get; set; }
        public string GioiTinh { get; set; }
        public string TinhTrangSucKhoe { get; set; }
        public int LoaiKyGuiId { get; set; }
        [StringLength(250)]
        public string GhiChu { get; set; }

    }
}