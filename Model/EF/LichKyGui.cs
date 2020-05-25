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
        public virtual LichHen LichHen { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        [StringLength(20)]
        public string LoaiKyGui { get; set; }
    }
}
