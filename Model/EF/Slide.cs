using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("Slide")]
    public class Slide
    {
        [Key]
        public int ID_Slide { get; set; }
        [Display(Name = "Đường dẫn ảnh")]
        public string Link_Image { get; set; }
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Display(Name = "Chi tiết")]
        public string ChiTiet { get; set; }
        [Display(Name = "Thứ tự")]
        public int ThuTu { get; set; }

    }
}
