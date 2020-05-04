using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Areas.Admin.Controllers
{
    public class DonHangManagementController : Controller
    {
        // GET: Admin/DonHangManagement
        public ActionResult Index(String searchString, int page = 1, int pagesize = 20)
        {
            var donHangRepo = new DonHangRepository();
            var model = donHangRepo.ListAllPaging(searchString, page, pagesize);
            return View(model);
        }
    }
}