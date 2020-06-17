using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("DonHangDetail")]
    public class DonHangDetail
    {
        [Key]
        public int ID_DonHangChiTiet { get; set; }
        public int ID_Item { get; set; }
        public int ID_DonHang { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public virtual DonHang DonHang { get; set; }
        public virtual Pet Pet { get; set; }


    }
}
