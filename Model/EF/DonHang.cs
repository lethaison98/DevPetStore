using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("DonHang")]
    public class DonHang
    {
        [Key]
        public int ID_DonHang { get; set; }
        public int? ID_KhachHang { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ConfirmDate { get; set; }

        public DateTime? ShipDate { get; set; }

        [StringLength(50)]
        public string ShipName { get; set; }

        [StringLength(20)]
        public string ShipMobile { get; set; }

        [StringLength(250)]
        public string ShipAddress { get; set; }

        public virtual KhachHang KhachHang { get; set; }
        public decimal TongTien { get; set; }
        public int TrangThaiDatHang { get; set; }
        public int TrangThaiGiaoHang { get; set; }
        public int TrangThaiDonHang { get; set; }
        public string LyDoHuy { get; set; }
        public string DanhGia { get; set; }

    }
}
