using Model.EF;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class LichHenController : Controller
    {
        // GET: LichHen
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LichHen lichHen)
        {
            var repo = new LichHenRepository();
            var id = repo.Insert(lichHen);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Giống Pet không thành công");
                }
            }
            return View();
        }
    }
}