using Model.EF;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Areas.Admin.Controllers
{
    public class PetManagementController : BaseController
    {
        // GET: Admin/PetManagement
        public ActionResult Index(String searchString, int page = 1, int pagesize = 10)
        {
            var petRepo = new PetRepository();
            var model = petRepo.ListAllPaging(searchString, page, pagesize);
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
        public ActionResult Create(Pet pet)
        {
            int x = pet.ID_Item;
            var petRepo = new PetRepository();
            int id = petRepo.InsertOrUpdate(pet);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    return RedirectToAction("Index", "PetManagement");
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
            var petRepo = new PetRepository();
            var pet = petRepo.GetByID(id);
            SetViewBag(pet.ID_GiongPet);
            return View(pet);

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Pet pet)
        {
            int? x = pet.ID_GiongPet;

            var petRepo = new PetRepository();
            int id = petRepo.InsertOrUpdate(pet);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    return RedirectToAction("Index", "PetManagement");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa Giống Pet không thành công");
                }
            }
            SetViewBag(pet.ID_GiongPet);
            return View("index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var petRepo = new PetRepository();
            petRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public void SetViewBag(int? selectedID = null)
        {
            var repo = new GiongPetRepository();
            ViewBag.ID_GiongPet = new SelectList(repo.ListAll(), "ID_GiongPet", "TenGiongPet", selectedID);
        }
    }
}