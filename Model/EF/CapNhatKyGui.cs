using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{

    [Table("CapNhatKyGui")]
    public class CapNhatKyGui
    {
        [Key]
        public int ID_CapNhatKyGui { get; set; }
        public int ID_LichKyGui { get; set; }
        public virtual LichKyGui LichKyGui { get; set; }
        
        [Display(Name = "Thời gian cập nhật")]
        public DateTime ThoiGianCapNhat { get; set; }
        [StringLength(250)]
        [Display(Name = "Link ảnh 1")]
        public string ImgLink1 { get; set; }
        [StringLength(250)]
        [Display(Name = "Link ảnh 2")]
        public string ImgLink2 { get; set; }
        [StringLength(250)]
        [Display(Name = "Link ảnh 3")]
        public string ImgLink3 { get; set; }
        [StringLength(250)]
        [Display(Name = "Tình trạng thú cưng")]
        public string TinhTrangThuCung { get; set; }
        [Display(Name = "Nội dung cập nhật")]
        public string NoiDungCapNhat { get; set; }
    }
}
