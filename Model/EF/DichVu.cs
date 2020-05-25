using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("DichVu")]
    public class DichVu
    {
        [Key]
        public int ID_DichVu { get; set; }

        [StringLength(50)]
        public string TenDichVu { get; set; }
        public decimal DonGia { get; set; }

        [StringLength(50)]
        public string DonViTinh { get; set; }
    }
}
