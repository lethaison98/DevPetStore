using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("KhuyenMai")]
    public class KhuyenMai
    {
        [Key]
        public int ID_KhuyenMai { get; set; }
        [StringLength(50)]
        public string ImageLink { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        public string ChiTietKhuyenMai { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
    }
}
