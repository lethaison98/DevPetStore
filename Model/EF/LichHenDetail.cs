﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("LichHenDetail")]
    public class LichHenDetail
    {
        [Key]
        public int ID_LichHenDetail { get; set; }
        public int ID_LichHen { get; set; }
        public int ID_KhachHang { get; set; }
        public int ID_DichVu { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual LichHen LichHen { get; set; }
        public virtual DichVu DichVu { get; set; }
    }
}
