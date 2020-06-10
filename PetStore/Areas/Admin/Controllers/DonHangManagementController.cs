using Model.Enums;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Areas.Admin.Controllers
{
    public class DonHangManagementController : Controller
    {
        // GET: Admin/DonHangManagement
        public ActionResult DonHangChuaXacNhan(String searchString, int page = 1, int pagesize = 20)
        {
            var donHangRepo = new DonHangRepository();
            var model = donHangRepo.ListAllPaging(searchString, page, pagesize, TrangThaiDonHangEnum.ChuaXacNhan);
            return View(model);
        }

        public ActionResult DonHangDaXacNhan(String searchString, int page = 1, int pagesize = 20)
        {
            var donHangRepo = new DonHangRepository();
            var model = donHangRepo.ListAllPaging(searchString, page, pagesize, TrangThaiDonHangEnum.DaXacNhan);
            return View(model);
        }


        [HttpPost]
        public JsonResult XacNhan (int id)
        {
            var donHangRepo = new DonHangRepository();
            var thanhCong = donHangRepo.XacNhan(id);
            return Json(new
            {
                status = thanhCong
            });
        }
        [HttpPost]
        public JsonResult TuChoi(int id)
        {
            var donHangRepo = new DonHangRepository();
            var thanhCong = donHangRepo.TuChoi(id);
            return Json(new
            {
                status = thanhCong
            });
        }
    }
}