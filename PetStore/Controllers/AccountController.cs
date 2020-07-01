using Model.Dto;
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
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var userRepo = new UserRepository();
                var khachHangRepo = new KhachHangRepository();
                if (userRepo.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (userRepo.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    User user = new User();
                    user.Ten = model.Name;
                    user.SoDienThoai = model.Phone;
                    user.Email = model.Email;
                    user.Status = true;
                    user.Username = model.UserName;
                    user.Password = model.Password;
                    int userid = userRepo.InsertOrUpdate(user);

                    KhachHang khachHang = new KhachHang();
                    khachHang.Ten = model.Name;
                    khachHang.ID_User = userid;
                    khachHang.GioiTinh = model.GioiTinh;
                    khachHang.NgaySinh = model.NamSinh;
                    khachHang.SoDienThoai = model.Phone;
                    khachHang.Email = model.Email;
                    khachHang.DiaChi = model.Address;
                    int khachHangid = khachHangRepo.InsertOrUpdate(khachHang);
                    if (userid > 0 && khachHangid > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModel();
                        return RedirectToAction("index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm User không thành công");
                    }
                }
            }

            return View(model);
        }
        [HttpGet]
        public ActionResult Edit()
        {
            var khachHangRepo = new KhachHangRepository();
            var userRepo = new UserRepository();
            var session = (PetStore.Common.UserLogin)Session[PetStore.Common.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("index", "Login");
            }
            else
            {
                var khachHang = khachHangRepo.GetByUserId(session.UserID);
                var user = userRepo.GetByID(session.UserID);
                var model = new RegisterModel();
                model.ID = session.UserID;
                model.Name = khachHang.Ten;
                model.Phone = khachHang.SoDienThoai;
                model.Email = khachHang.Email;
                model.Address = khachHang.DiaChi;
                model.NamSinh = khachHang.NgaySinh;
                model.GioiTinh = khachHang.GioiTinh;
                model.UserName = user.Username;
                model.Password = user.Password;
                model.ConfirmPassword = user.Password;
                return View(model);
            }

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var userRepo = new UserRepository();
                var khachHangRepo = new KhachHangRepository();
                if (userRepo.CheckEmail(model.Email) && !userRepo.GetByID(model.ID).Email.Equals(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    User user = new User();
                    user.ID_User = model.ID;
                    user.Ten = model.Name;
                    user.SoDienThoai = model.Phone;
                    user.Email = model.Email;
                    user.Status = true;
                    user.Password = model.Password;
                    int userid = userRepo.InsertOrUpdate(user);

                    KhachHang khachHang = new KhachHang();
                    khachHang.ID_KhachHang = khachHangRepo.GetByUserId(userid).ID_KhachHang;
                    khachHang.Ten = model.Name;
                    khachHang.ID_User = userid;
                    khachHang.GioiTinh = model.GioiTinh;
                    khachHang.NgaySinh = model.NamSinh;
                    khachHang.SoDienThoai = model.Phone;
                    khachHang.Email = model.Email;
                    khachHang.DiaChi = model.Address;
                    int khachHangid = khachHangRepo.InsertOrUpdate(khachHang);
                    if (userid > 0 && khachHangid > 0)
                    {
                        ViewBag.Success = "Cập nhật thành công";
                        model = new RegisterModel();
                        return RedirectToAction("index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Chỉnh sửa User không thành công");
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult DonHangCuaToi()
        {
            var khachHangRepo = new KhachHangRepository();
            var userRepo = new UserRepository();
            var session = (PetStore.Common.UserLogin)Session[PetStore.Common.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("index", "Login");
            }
            else
            {
                var khachHang = khachHangRepo.GetByUserId(session.UserID);
                var list = new List<DonHangDto>();
                list = new DonHangRepository().LayDanhSachDonHangByKhachHangId(khachHang.ID_KhachHang);
                return View(list);
            }

        }
        [HttpPost]
        public JsonResult HuyDonHang(int id)
        {
            var donHangRepo = new DonHangRepository();
            var thanhCong = donHangRepo.TuChoi(id);
            return Json(new
            {
                status = thanhCong
            });
        }
        [HttpPost]
        public JsonResult HoanThanhDonHang(int id)
        {
            var donHangRepo = new DonHangRepository();
            var thanhCong = donHangRepo.HoanThanh(id);
            return Json(new
            {
                status = thanhCong
            });
        }


        [HttpGet]
        public ActionResult LichHenCuaToi()
        {
            var khachHangRepo = new KhachHangRepository();
            var userRepo = new UserRepository();
            var session = (PetStore.Common.UserLogin)Session[PetStore.Common.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("index", "Login");
            }
            else
            {
                var khachHang = khachHangRepo.GetByUserId(session.UserID);
                var list = new List<LichHenDto>();
                list = new LichHenRepository().LayDanhSachLichHenByKhachHangId(khachHang.ID_KhachHang);
                return View(list);
            }

        }

        [HttpPost]
        public JsonResult HuyLichHen(int id)
        {
            var LichHenRepo = new LichHenRepository();
            var thanhCong = LichHenRepo.TuChoi(id);
            return Json(new
            {
                status = thanhCong
            });
        }

        [HttpPost]
        public JsonResult HoanThanhLichHen(int id)
        {
            var LichHenRepo = new LichHenRepository();
            var thanhCong = LichHenRepo.HoanThanh(id);
            return Json(new
            {
                status = thanhCong
            });
        }

        [HttpGet]
        public ActionResult KyGuiCuaToi()
        {
            var khachHangRepo = new KhachHangRepository();
            var userRepo = new UserRepository();
            var session = (PetStore.Common.UserLogin)Session[PetStore.Common.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("index", "Login");
            }
            else
            {
                var khachHang = khachHangRepo.GetByUserId(session.UserID);
                var list = new List<KyGuiDto>();
                list = new KyGuiRepository().LayDanhSachKyGuiByKhachHangId(khachHang.ID_KhachHang);
                return View(list);
            }

        }
        [HttpPost]
        public JsonResult HuyKyGui(int id)
        {
            var kyGuiRepo = new KyGuiRepository();
            var thanhCong = kyGuiRepo.TuChoi(id);
            return Json(new
            {
                status = thanhCong
            });
        }

        [HttpPost]
        public JsonResult HoanThanhKyGui(int id)
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