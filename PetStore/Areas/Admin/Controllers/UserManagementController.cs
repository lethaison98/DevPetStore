using Model.EF;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace PetStore.Areas.Admin.Controllers
{
    public class UserManagementController : BaseController
    {
        // GET: Admin/UserManagement
        public ActionResult Index(int page =1, int pagesize = 10)
        {
            var userRepo = new UserRepository();
            var model = userRepo.ListAllPaging(page, pagesize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            int x = user.ID_User;
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
                    ModelState.AddModelError("", "Thêm User không thành công");
                }
            }
            return View ("index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var userRepo = new UserRepository();
            var user = userRepo.GetByID(id);
            return View(user);
            
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            int x = user.ID_User;
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
                    ModelState.AddModelError("", "Sửa User không thành công");
                }
            }
            return View("index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var userRepo = new UserRepository();
            userRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}