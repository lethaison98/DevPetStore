using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class HotDealDto
    {
        public int ID_HotDeal { get; set; }
        public decimal GiaKhuyenMai { get; set; }
        public int ID_Item { get; set; }
        public string Ten_Pet { get; set; }
        public int? ID_GiongPet { get; set; }
        public string Image { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string MetaTitle { get; set; }
        public string MoTa { get; set; }
        public string ChiTiet { get; set; }
        public string MauLong { get; set; }
        public string NguonGoc { get; set; }
        public decimal GiaTien { get; set; }
        public bool? Status { get; set; }
        public bool? GioiTinh { get; set; }
    }
}
