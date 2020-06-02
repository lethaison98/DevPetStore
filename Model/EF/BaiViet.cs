using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("BaiViet")]
    public class BaiViet
    {
        [Key]
        public int ID_BaiViet { get; set; }
        [StringLength(250)]
        public string Title { get; set; }
        [Display(Name = "Ảnh 1")]
        [StringLength(250)]
        public string ImageLink1 { get; set; }
        [Display(Name = "Đoạn 1")]
        public string Para1 { get; set; }
        [Display(Name = "Ảnh 2")]
        [StringLength(250)]
        public string ImgLink2 { get; set; }

        [Display(Name = "Đoạn 2")]
        public string Para2 { get; set; }
        [Display(Name = "Ảnh 3")]
        [StringLength(250)]
        public string ImgLink3 { get; set; }

        [Display(Name = "Đoạn 3")]
        public string Para3 { get; set; }
        public DateTime CreateDate { get; set; }
        public string Metatitle { get; set; }
        
    }
}
