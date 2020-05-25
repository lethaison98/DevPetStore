using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("LichHen")]
    public class LichHen
    {
        [Key]
        public int LichHen_ID { get; set; }
        public int? ID_KhachHang { get; set; }
        public int? ID_GiongPet { get; set; }
        public virtual KhachHang KhachHang{get;set;}
        public virtual GiongPet GiongPet { get; set; }

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
        public int? TrangThaiLichHen { get; set; }


    }
}
