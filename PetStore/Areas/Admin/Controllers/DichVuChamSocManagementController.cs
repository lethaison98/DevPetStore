using Model.EF;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Areas.Admin.Controllers
{
    public class DichVuChamSocManagementController : BaseController
    {
        // GET: Admin/DichVuChamSocManagement
        public ActionResult Index()
        {
            var DichVuChamSocRepo = new DichVuChamSocRepository();
            var model = DichVuChamSocRepo.ListAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(DichVuChamSoc DichVuChamSoc)
        {
            var DichVuChamSocRepo = new DichVuChamSocRepository();
            int id = DichVuChamSocRepo.InsertOrUpdate(DichVuChamSoc);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    return RedirectToAction("Index", "DichVuChamSocManagement");
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
            var DichVuChamSocRepo = new DichVuChamSocRepository();
            var DichVuChamSoc = DichVuChamSocRepo.GetByID(id);
            return View(DichVuChamSoc);

        }

        [HttpPost]
        public ActionResult Edit(DichVuChamSoc DichVuChamSoc)
        {
            var DichVuChamSocRepo = new DichVuChamSocRepository();
            int id = DichVuChamSocRepo.InsertOrUpdate(DichVuChamSoc);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    return RedirectToAction("Index", "DichVuChamSocManagement");
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
            var DichVuChamSocRepo = new DichVuChamSocRepository();
            DichVuChamSocRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}