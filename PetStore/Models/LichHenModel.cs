using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    public class LichHenModel
    {
        public int LichHen_ID { get; set; }
        public int ID_KhachHang { get; set; }
        public int? ID_GiongPet { get; set; }

        [StringLength(50)]
        public string TenNguoiHen { get; set; }

        [StringLength(20)]
        public string SoDienThoai { get; set; }

        [StringLength(30)]
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public string NgayHen { get; set; }
        public string GioHen { get; set; }
        [StringLength(250)]
        public string GhiChu { get; set; }
        public int TrangThaiLichHen { get; set; }

        public List<DichVuModel> DanhSachDichVu { get; set; }
    }
}