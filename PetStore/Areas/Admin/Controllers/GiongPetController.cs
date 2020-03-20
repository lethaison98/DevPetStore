using Model.EF;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Areas.Admin.Controllers
{
    public class GiongPetController : BaseController
    {
        // GET: Admin/GiongPet
        public ActionResult Index(String searchString, int page = 1, int pagesize = 10)
        {
            var giongPetRepo = new GiongPetRepository();
            var model = giongPetRepo.ListAllPaging(searchString, page, pagesize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(GiongPet giongPet)
        {
            int x = giongPet.ID_GiongPet;
            var giongPetRepo = new GiongPetRepository();
            int id = giongPetRepo.InsertOrUpdate(giongPet);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    return RedirectToAction("Index", "GiongPet");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Giống Pet không thành công");
                }
            }
            SetViewBag();
            return View("index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var giongPetRepo = new GiongPetRepository();
            var giongPet = giongPetRepo.GetByID(id);
            SetViewBag(giongPet.ID_DanhMuc);
            return View(giongPet);

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(GiongPet giongPet)
        {
            int? x = giongPet.ID_DanhMuc;

            var giongPetRepo = new GiongPetRepository();
            int id = giongPetRepo.InsertOrUpdate(giongPet);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    return RedirectToAction("Index", "GiongPet");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa Giống Pet không thành công");
                }
            }
            SetViewBag(giongPet.ID_DanhMuc);
            return View("index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var giongPetRepo = new GiongPetRepository();
            giongPetRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public void SetViewBag(int? selectedID = null)
        {
            var repo = new DanhMucRepository();
            ViewBag.ID_DanhMuc = new SelectList(repo.ListAll(), "ID_DanhMuc", "TenDanhMuc", selectedID);
        }
    }
}