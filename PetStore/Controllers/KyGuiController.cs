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
    public class KyGuiController : Controller
    {
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
                var kyGui = new KyGuiModel();
                kyGui.ID_KhachHang = khachHang.ID_KhachHang;
                kyGui.TenKhachHang = khachHang.Ten;
                kyGui.SoDienThoai = khachHang.SoDienThoai;
                kyGui.Email = khachHang.Email;
                SetViewBag();
                return View(kyGui);
            }

        }

        [HttpPost]
        public ActionResult Index(KyGuiModel kyGuiModel)
        {
            if (ModelState.IsValid)
            {
                var repo = new LichHenRepository();
                var lichHen = new LichHen();
                lichHen.TenNguoiHen = kyGuiModel.TenKhachHang;
                lichHen.SoDienThoai = kyGuiModel.SoDienThoai;
                lichHen.Email = kyGuiModel.Email;
                lichHen.NgayHen = kyGuiModel.NgayHen;
                lichHen.GioHen = kyGuiModel.GioHen;
                lichHen.GhiChu = kyGuiModel.GhiChu;
                lichHen.LoaiThuCung = kyGuiModel.LoaiThuCung;
                lichHen.GiongThuCung = kyGuiModel.GiongThuCung;
                lichHen.ID_KhachHang = kyGuiModel.ID_KhachHang;
                lichHen.LoaiLichHen = 2;
                var id = repo.Insert(lichHen);

                var lichKyGui = new LichKyGui();
                lichKyGui.ID_LichHen = id;
                lichKyGui.TuNgay = kyGuiModel.TuNgay;
                lichKyGui.TuGio = kyGuiModel.TuGio;
                lichKyGui.DenNgay = kyGuiModel.DenNgay;
                lichKyGui.DenGio = kyGuiModel.DenGio;
                lichKyGui.LoaiKyGuiID = kyGuiModel.LoaiKyGuiId;
                lichKyGui.TenPet = kyGuiModel.TenPet;
                lichKyGui.SoThang = kyGuiModel.SoThang;
                lichKyGui.CanNang = kyGuiModel.CanNang;
                lichKyGui.GioiTinh = kyGuiModel.GioiTinh;
                lichKyGui.DonTraTaiNha = kyGuiModel.DonTraTaiNha;
                lichKyGui.DiaChiDonTra = lichKyGui.DiaChiDonTra;
                lichKyGui.TinhTrangSucKhoe = kyGuiModel.TinhTrangSucKhoe;
                var lichKyGuiId = repo.InsertLichKyGui(lichKyGui);
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