using Model.Repository;
using PetStore.Models;
using PetStore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
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
                var result = userRepo.Login(model.Username, model.Password);
                if (result == 1)
                {
                    var user = userRepo.GetByUsername(model.Username);
                    var userSession = new UserLogin();
                    userSession.UserName = user.Username;
                    userSession.UserID = user.ID_User;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    if (result == 0)
                    {
                        ModelState.AddModelError("", "Tài khoản không tồn tại");
                    }
                    if (result == 2)
                    {
                        ModelState.AddModelError("", "Tài khoản đã bị khóa");
                    }
                    if (result == 3)
                    {
                        ModelState.AddModelError("", "Mật khẩu sai");
                    }

                }
            }

            return View("Index");
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }
    }
}