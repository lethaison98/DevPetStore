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
            SetViewBag();
            var repo = new LichHenRepository();
            var kyGuiRepo = new KyGuiRepository();
            var lichHen = new LichHen();
            lichHen.TenNguoiHen = kyGuiModel.TenKhachHang;
            lichHen.SoDienThoai = kyGuiModel.SoDienThoai;
            lichHen.Email = kyGuiModel.Email;
            lichHen.NgayHen = kyGuiModel.TuNgay;
            lichHen.GioHen = kyGuiModel.TuGio;
            lichHen.GhiChu = kyGuiModel.GhiChu;
            lichHen.LoaiThuCung = kyGuiModel.LoaiThuCung;
            lichHen.GiongThuCung = kyGuiModel.GiongThuCung;
            lichHen.ID_KhachHang = kyGuiModel.ID_KhachHang;
            lichHen.CanNang = kyGuiModel.CanNang;
            lichHen.LoaiLichHen = 2;
            lichHen.TrangThaiLichHen = 1;
            lichHen.TongTien = kyGuiRepo.CapNhatChiPhi(kyGuiModel.LoaiThuCung, kyGuiModel.CanNang, kyGuiModel.ID_DichVuKyGui, kyGuiModel.TuNgay, kyGuiModel.TuGio, kyGuiModel.DenNgay, kyGuiModel.DenGio); 
            var id = repo.Insert(lichHen);

            var lichKyGui = new LichKyGui();
            lichKyGui.ID_LichHen = id;
            lichKyGui.TuNgay = kyGuiModel.TuNgay;
            lichKyGui.TuGio = kyGuiModel.TuGio;
            lichKyGui.DenNgay = kyGuiModel.DenNgay;
            lichKyGui.DenGio = kyGuiModel.DenGio;
            lichKyGui.ID_DichVuKyGui = kyGuiModel.ID_DichVuKyGui;
            lichKyGui.TenPet = kyGuiModel.TenPet;
            lichKyGui.SoThang = kyGuiModel.SoThang;
            lichKyGui.GioiTinh = kyGuiModel.GioiTinh;
            lichKyGui.DonTraTaiNha = kyGuiModel.DonTraTaiNha;
            lichKyGui.DiaChiDonTra = kyGuiModel.DiaChiDonTra;
            lichKyGui.TenLoaiKyGui = new DichVuKyGuiRepository().GetByID(kyGuiModel.ID_DichVuKyGui).TenDichVuKyGui;
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
            
            return View();
        }
        public void SetViewBag(int? selectedID = null)
        {
            var repo = new DichVuKyGuiRepository();
            ViewBag.ID_DichVuKyGui = new SelectList(repo.ListAll(), "ID_DichVuKyGui", "TenDichVuKyGui", selectedID);
            ViewBag.BangGiaDichVu = repo.ListAll();
        }
    }
}