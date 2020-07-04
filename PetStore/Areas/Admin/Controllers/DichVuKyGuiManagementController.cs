using Model.EF;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Areas.Admin.Controllers
{
    public class DichVuKyGuiManagementController : BaseController
    {
        public ActionResult Index()
        {
            var DichVuKyGuiRepo = new DichVuKyGuiRepository();
            var model = DichVuKyGuiRepo.ListAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(DichVuKyGui DichVuKyGui)
        {
            var DichVuKyGuiRepo = new DichVuKyGuiRepository();
            int id = DichVuKyGuiRepo.InsertOrUpdate(DichVuKyGui);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    return RedirectToAction("Index", "DichVuKyGuiManagement");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Dịch vụ không thành công");
                }
            }
            return View("index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var DichVuKyGuiRepo = new DichVuKyGuiRepository();
            var DichVuKyGui = DichVuKyGuiRepo.GetByID(id);
            return View(DichVuKyGui);

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(DichVuKyGui DichVuKyGui)
        {
            var DichVuKyGuiRepo = new DichVuKyGuiRepository();
            int id = DichVuKyGuiRepo.InsertOrUpdate(DichVuKyGui);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    return RedirectToAction("Index", "DichVuKyGuiManagement");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa Dịch vụ chăm sóc không thành công");
                }
            }
            return View("index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var DichVuKyGuiRepo = new DichVuKyGuiRepository();
            DichVuKyGuiRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}