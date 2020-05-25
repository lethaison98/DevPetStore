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
            var khachHangRepo = new KhachHangRepository();
            var session = (PetStore.Common.UserLogin)Session[PetStore.Common.CommonConstants.USER_SESSION];
            var khachHang = khachHangRepo.GetByUserId(session.UserID);
            var lichHen = new LichHen();
            lichHen.TenNguoiHen = khachHang.Ten;
            lichHen.SoDienThoai = khachHang.SoDienThoai;
            lichHen.Email = khachHang.Email;
            SetViewBag();
            return View(lichHen);
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
                    ModelState.AddModelError("", "Thêm Lịch hẹn không thành công");
                }
            }
            return View();
        }
        public void SetViewBag(int? selectedID = null)
        {
            var repo = new GiongPetRepository();
           
            ViewBag.ID_GiongPet = new SelectList(repo.ListAll(), "ID_GiongPet", "TenGiongPet", selectedID);
        }
    }
}