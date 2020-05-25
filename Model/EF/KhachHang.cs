using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public int ID_KhachHang { get; set; }
        public int ID_User { get; set; }
        public virtual User User { get; set; }
        [StringLength(50)]
        [Display(Name = "Họ Tên")]
        public string Ten { get; set; }
        [Display(Name = "Giới tính (Nam)")]
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        [StringLength(250)]
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(30)]
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }
       
    }
}
