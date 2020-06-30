using Model.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enums
{
    public enum TrangThaiDonHangEnum
    {
        [TrangThai(1,"Chưa xác nhận")]
        ChuaXacNhan ,
        [TrangThai(2, "Đã xác nhận")]
        DaXacNhan,
        [TrangThai(3, "Đã hoàn thành")]
        DaHoanThanh,
        [TrangThai(4, "Đã hủy")]
        DaHuy,
    }
    public enum TrangThaiLichHenEnum
    {
        [TrangThai(1, "Chưa xác nhận")]
        ChuaXacNhan,
        [TrangThai(2, "Đã xác nhận")]
        DaXacNhan,
        [TrangThai(3, "Đang thực ký gửi")]
        DangKyGui,
        [TrangThai(4, "Đã hủy")]
        DaHuy,
        [TrangThai(5, "Đã hoàn thành")]
        DaHoanThanh,
    }
}
