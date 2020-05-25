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
            return View();
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(User user)
        {
            int x = user.ID_User;
            var userRepo = new UserRepository();
            int id = userRepo.InsertOrUpdate(user);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm User không thành công");
                }
            }
            return View("Index","Home");
        }

    }
}