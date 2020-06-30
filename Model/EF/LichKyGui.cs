using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("LichKyGui")]
    public class LichKyGui
    {
        [Key]
        public int ID_LichKyGui { get; set; }
        public int ID_LichHen { get; set; }
        public string TuNgay { get; set; }
        public string TuGio { get; set; }
        public string DenNgay { get; set; }
        public string DenGio { get; set; }
        public string TenPet { get; set; }
        public int SoThang { get; set; }
        public decimal CanNang { get; set; }
        public string GioiTinh { get; set; }
        public string TinhTrangSucKhoe { get; set; }
        public bool DonTraTaiNha { get; set; }
        public string DiaChiDonTra { get; set; }
        public int LoaiKyGuiID { get; set; }
        [StringLength(20)]
        public string TenLoaiKyGui { get; set; }
        public virtual LichHen LichHen { get; set; }
    }
}
