using Model.EF;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Areas.Admin.Controllers
{
    public class BaiVietManagementController : BaseController
    {
        // GET: Admin/GiongPet
        public ActionResult Index(String searchString, int page = 1, int pagesize = 10)
        {
            var baiVietRepo = new BaiVietRepository();
            var model = baiVietRepo.ListAllPaging(searchString, page, pagesize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(BaiViet baiViet)
        {
            var baiVietRepo = new BaiVietRepository();
            int id = baiVietRepo.InsertOrUpdate(baiViet);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    return RedirectToAction("Index", "BaiVietManagement");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm bài viết không thành công");
                }
            }
            return View("index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var baiVietRepo = new BaiVietRepository();
            var baiViet = baiVietRepo.GetByID(id);
            return View(baiViet);

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(BaiViet baiViet)
        {
            var baiVietRepo = new BaiVietRepository();
            int id = baiVietRepo.InsertOrUpdate(baiViet);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    return RedirectToAction("Index", "BaiVietManagement");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa bài viết không thành công");
                }
            }
            return View("index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var baiVietRepo = new BaiVietRepository();
            baiVietRepo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}