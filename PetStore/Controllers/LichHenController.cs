using Model.EF;
using Model.Repository;
using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class LichHenController : Controller
    {
        // GET: LichHen
        [HttpGet]
        public ActionResult Index()
        {
            var khachHangRepo = new KhachHangRepository();
            var session = (PetStore.Common.UserLogin)Session[PetStore.Common.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("index", "Login");
            }
            else
            {
                var khachHang = khachHangRepo.GetByUserId(session.UserID);
                var lichHen = new LichHenModel();
                lichHen.ID_KhachHang = khachHang.ID_KhachHang;
                lichHen.TenNguoiHen = khachHang.Ten;
                lichHen.SoDienThoai = khachHang.SoDienThoai;
                lichHen.Email = khachHang.Email;
                var dichVuRepo = new DichVuRepository();
                var listDichVu = dichVuRepo.ListAll();
                List<DichVuModel> list = new List<DichVuModel>();
                foreach(var item in listDichVu)
                {
                    list.Add(new DichVuModel { dichVu = item, available = false });
                }
                lichHen.DanhSachDichVu = list;
                SetViewBag();
                return View(lichHen);
            }

        }

        [HttpPost]
        public ActionResult Index(LichHenModel lichHenModel)
        {
            if (ModelState.IsValid)
            {
                var repo = new LichHenRepository();
                var lichHen = new LichHen();
                lichHen.TenNguoiHen = lichHenModel.TenNguoiHen;
                lichHen.SoDienThoai = lichHenModel.SoDienThoai;
                lichHen.Email = lichHenModel.Email;
                lichHen.NgayHen = lichHenModel.NgayHen;
                lichHen.GioHen = lichHenModel.GioHen;
                lichHen.GhiChu = lichHenModel.GhiChu;
                lichHen.ID_GiongPet = lichHenModel.ID_GiongPet;
                lichHen.ID_KhachHang = lichHenModel.ID_KhachHang;
                var id = repo.Insert(lichHen);

                foreach(var item in lichHenModel.DanhSachDichVu)
                {
                    if (item.available)
                    {
                        var lichHenDetail = new LichHenDetail();
                        lichHenDetail.ID_LichHen = id;
                        lichHenDetail.ID_KhachHang = lichHenModel.ID_KhachHang;
                        lichHenDetail.ID_DichVu = item.dichVu.ID_DichVu;
                        var idLichHenDetail = repo.InsertLichHenDetail(lichHenDetail);
                    }

                }

                if (id > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Lịch hẹn không thành công");
                }
            }
            return View();
        }
        public void SetViewBag(int? selectedID = null)
        {
            var repo = new GiongPetRepository();     
            ViewBag.ID_GiongPet = new SelectList(repo.ListAll(), "ID_GiongPet", "TenGiongPet", selectedID);

        }
    }
}