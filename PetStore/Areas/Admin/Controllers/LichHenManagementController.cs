using Model.Enums;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Areas.Admin.Controllers
{
    public class LichHenManagementController : BaseController
    {
        public ActionResult LichHenChuaXacNhan(String searchString, int page = 1, int pagesize = 20)
        {
            var LichHenRepo = new LichHenRepository();
            var model = LichHenRepo.LayDanhSachLichHenTheoTrangThai(searchString, page, pagesize, TrangThaiLichHenEnum.ChuaXacNhan);
            return View(model);
        }

        public ActionResult LichHenDaXacNhan(String searchString, int page = 1, int pagesize = 20)
        {
            var LichHenRepo = new LichHenRepository();
            var model = LichHenRepo.LayDanhSachLichHenTheoTrangThai(searchString, page, pagesize, TrangThaiLichHenEnum.DaXacNhan);
            return View(model);
        }

        public ActionResult LichHenDaHoanThanh(String searchString, int page = 1, int pagesize = 20)
        {
            var LichHenRepo = new LichHenRepository();
            var model = LichHenRepo.LayDanhSachLichHenTheoTrangThai(searchString, page, pagesize, TrangThaiLichHenEnum.DaHoanThanh);
            return View(model);
        }
        public ActionResult LichHenDaHuy(String searchString, int page = 1, int pagesize = 20)
        {
            var LichHenRepo = new LichHenRepository();
            var model = LichHenRepo.LayDanhSachLichHenTheoTrangThai(searchString, page, pagesize, TrangThaiLichHenEnum.DaHuy);
            return View(model);
        }
        public ActionResult ChiTietLichhen(int id)
        {
            int page = 1;
            int pagesize = 20;
            var lichHenRepo = new LichHenRepository();
            var model = lichHenRepo.LayDanhSachLichHenChiTiet(id, page, pagesize);
            ViewBag.LichHen = lichHenRepo.GetLichHenById(id);
            return View(model);
        }

        [HttpPost]
        public JsonResult XacNhan(int id)
        {
            var LichHenRepo = new LichHenRepository();
            var thanhCong = LichHenRepo.XacNhan(id);
            return Json(new
            {
                status = thanhCong
            });
        }
        [HttpPost]
        public JsonResult TuChoi(int id, string lydo)
        {
            var LichHenRepo = new LichHenRepository();
            var thanhCong = LichHenRepo.TuChoi(id, lydo);
            return Json(new
            {
                status = thanhCong
            });
        }

        [HttpPost]
        public JsonResult HoanThanh(int id)
        {
            var LichHenRepo = new LichHenRepository();
            var thanhCong = LichHenRepo.HoanThanh(id);
            return Json(new
            {
                status = thanhCong
            });
        }
    }
}