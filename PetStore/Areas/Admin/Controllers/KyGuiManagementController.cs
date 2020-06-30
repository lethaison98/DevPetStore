using Model.Enums;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Areas.Admin.Controllers
{
    public class KyGuiManagementController : BaseController
    {
        // GET: Admin/DonHangManagement
        public ActionResult KyGuiChuaXacNhan(String searchString, int page = 1, int pagesize = 20)
        {
            var kyGuiRepo = new KyGuiRepository();
            var model = kyGuiRepo.LayDanhSachKyGuiTheoTrangThai(searchString, page, pagesize, TrangThaiLichHenEnum.ChuaXacNhan);
            return View(model);
        }

        public ActionResult KyGuiDaXacNhan(String searchString, int page = 1, int pagesize = 20)
        {
            var kyGuiRepo = new KyGuiRepository();
            var model = kyGuiRepo.LayDanhSachKyGuiTheoTrangThai(searchString, page, pagesize, TrangThaiLichHenEnum.DaXacNhan);
            return View(model);
        }
        public ActionResult KyGuiDangThucHien(String searchString, int page = 1, int pagesize = 20)
        {
            var kyGuiRepo = new KyGuiRepository();
            var model = kyGuiRepo.LayDanhSachKyGuiTheoTrangThai(searchString, page, pagesize, TrangThaiLichHenEnum.DangKyGui);
            return View(model);
        }
        public ActionResult KyGuiDaHoanThanh(String searchString, int page = 1, int pagesize = 20)
        {
            var kyGuiRepo = new KyGuiRepository();
            var model = kyGuiRepo.LayDanhSachKyGuiTheoTrangThai(searchString, page, pagesize, TrangThaiLichHenEnum.DaHoanThanh);
            return View(model);
        }
        public ActionResult KyGuiDaHuy(String searchString, int page = 1, int pagesize = 20)
        {
            var kyGuiRepo = new KyGuiRepository();
            var model = kyGuiRepo.LayDanhSachKyGuiTheoTrangThai(searchString, page, pagesize, TrangThaiLichHenEnum.DaHuy);
            return View(model);
        }
        public ActionResult ChiTietKyGui(int id)
        {
            var kyGuiRepo = new KyGuiRepository();
            var model = kyGuiRepo.GetKyGuiById(id);
            return View(model);
        }

        [HttpPost]
        public JsonResult XacNhan (int id)
        {
            var kyGuiRepo = new KyGuiRepository();
            var thanhCong = kyGuiRepo.XacNhan(id);
            return Json(new
            {
                status = thanhCong
            });
        }
        [HttpPost]
        public JsonResult TuChoi(int id)
        {
            var kyGuiRepo = new KyGuiRepository();
            var thanhCong = kyGuiRepo.TuChoi(id);
            return Json(new
            {
                status = thanhCong
            });
        }
        [HttpPost]
        public JsonResult DangKyGui(int id)
        {
            var kyGuiRepo = new KyGuiRepository();
            var thanhCong = kyGuiRepo.DangKyGui(id);
            return Json(new
            {
                status = thanhCong
            });
        }
        [HttpPost]
        public JsonResult HoanThanh(int id)
        {
            var kyGuiRepo = new KyGuiRepository();
            var thanhCong = kyGuiRepo.HoanThanh(id);
            return Json(new
            {
                status = thanhCong
            });
        }
    }
}