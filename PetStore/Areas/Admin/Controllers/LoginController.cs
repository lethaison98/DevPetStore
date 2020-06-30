using Model.Repository;
using PetStore.Areas.Admin.Models;
using PetStore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var userRepo = new UserRepository();
                var result = userRepo.Login(model.Username, model.Password, true);
                if (result ==1)
                {
                    var user = userRepo.GetByUsername(model.Username);
                    var userSession = new UserLogin();
                    userSession.UserName = user.Username;
                    userSession.UserID = user.ID_User;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("index", "HomeAdmin");
                }
                else
                {
                    if(result == 0)
                    {
                        ModelState.AddModelError("", "Tài khoản không tồn tại");
                    }
                    if(result == 2)
                    {
                        ModelState.AddModelError("", "Tài khoản đã bị khóa");
                    }
                    if(result == 3)
                    {
                        ModelState.AddModelError("", "Mật khẩu sai");
                    }
                    if(result == 4)
                    {
                        ModelState.AddModelError("", "Bạn không có quyền");
                    }
                    
                }
            }
            
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}