using Model.EF;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Areas.Admin.Controllers
{
    public class SlideManagementController : Controller
    {
       
        // GET: Admin/SlideManagement
        public ActionResult Index(String searchString, int page = 1, int pagesize = 10)
        {
            var slideRepo = new SlideRepository();
            var model = slideRepo.ListAllPaging(searchString, page, pagesize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Slide slide)
        {
            var slideRepo = new SlideRepository();
            int id = slideRepo.InsertOrUpdate(slide);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    return RedirectToAction("Index", "SlideManagement");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Slide không thành công");
                }
            }
            return View("index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var slideRepo = new SlideRepository();
            var slide = slideRepo.GetByID(id);
            return View(slide);

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Slide slide)
        {
            var slideRepo = new SlideRepository();

            int id = slideRepo.InsertOrUpdate(slide);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    return RedirectToAction("Index", "SlideManagement");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa Slide không thành công");
                }
            }
            return View("index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var slideRepo = new SlideRepository();
            slideRepo.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}