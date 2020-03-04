using Model.EF;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Areas.Admin.Controllers
{
    public class UserManagermentController : BaseController
    {
        // GET: Admin/UserManagerment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(User user)
        {
            var userRepo = new UserRepository();
            int id = userRepo.InsertOrUpdate(user);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    return RedirectToAction("Index", "UserManagement");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm User thành công");
                }
            }
            return View ("index");
        }
    }
}