using Model.EF;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Areas.Admin.Controllers
{
    public class HotDealManagementController : Controller
    {
        // GET: Admin/HotDealManagement
        public ActionResult Index(String searchString, int page = 1, int pagesize = 10)
        {
            var HotDealRepo = new HotDealRepository();
            var model = HotDealRepo.ListAllEntity();
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
        public ActionResult Create(HotDeal HotDeal)
        {
            var HotDealRepo = new HotDealRepository();
            int id = HotDealRepo.InsertOrUpdate(HotDeal);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    return RedirectToAction("Index", "HotDealManagement");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm HotDeal không thành công");
                }
            }
            return View("index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var HotDealRepo = new HotDealRepository();
            var HotDeal = HotDealRepo.GetByID(id);
            SetViewBag();
            return View(HotDeal);


        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(HotDeal HotDeal)
        {
            var HotDealRepo = new HotDealRepository();
            int id = HotDealRepo.InsertOrUpdate(HotDeal);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    return RedirectToAction("Index", "HotDealManagement");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa HotDeal không thành công");
                }
            }
            return View("index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var HotDealRepo = new HotDealRepository();
            HotDealRepo.Delete(id);
            return RedirectToAction("Index");
        }
        public void SetViewBag(int? selectedID = null)
        {
            var repo = new PetRepository();
            ViewBag.ID_Item = new SelectList(repo.ListAllPaging("",1,100), "ID_Item", "Ten_Pet", selectedID);
        }
    }
}