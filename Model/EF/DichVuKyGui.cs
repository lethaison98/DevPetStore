using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("DichVuKyGui")]
    public class DichVuKyGui
    {
        [Key]
        public int ID_DichVuKyGui { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên gói ký gửi")]
        public string TenDichVuKyGui { get; set; }
        [Display(Name = "Giới thiệu gói ký gửi")]
        public string GioiThieuDichVu { get; set; }

        [StringLength(50)]
        [Display(Name = "Đơn vị tính")]
        public string DonViTinh { get; set; }
        [Display(Name = " Đơn giá dịch vụ chó dưới 10 kg")]
        public decimal Cho_0_10 { get; set; }
        [Display(Name = "Đơn giá dịch vụ chó 10-15kg")]
        public decimal Cho_10_15 { get; set; }
        [Display(Name = "Đơn giá dịch vụ chó 15-20kg")]
        public decimal Cho_15_20 { get; set; }
        [Display(Name = "Đơn giá dịch vụ chó 20-25kg")]
        public decimal Cho_20_25 { get; set; }
        [Display(Name = "Đơn giá dịch vụ chó trên 25kg")]
        public decimal Cho_over25 { get; set; }
        [Display(Name = "Đơn giá dịch vụ mèo dưới 2kg")]
        public decimal Meo_0_2 { get; set; }
        [Display(Name = "Đơn giá dịch vụ mèo 2-5kg")]
        public decimal Meo_2_5 { get; set; }
        [Display(Name = "Đơn giá dịch vụ mèo 5-8kg")]
        public decimal Meo_5_8 { get; set; }
        [Display(Name = "Đơn giá dịch vụ mèo trên 8kg")]
        public decimal Meo_over8 { get; set; }
    }
}
