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
        public int Slide_ID { get; set; }
        public string Link_Image { get; set; }
        public string TieuDe { get; set; }
        public string ChiTiet { get; set; }
        public int ThuTu { get; set; }

    }
}
