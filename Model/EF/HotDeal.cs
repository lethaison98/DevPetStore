using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("HotDeal")]
    public class HotDeal
    {
        [Key]
        public int ID_HotDeal { get; set; }
        public int ID_Item { get; set; }
        [Display(Name = "Giá khuyến mãi")]
        public decimal GiaKhuyenMai { get; set; }
    }
}
