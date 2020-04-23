using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Areas.Admin.Controllers
{
    public class DanhMucController : BaseController
    {
        // GET: Admin/DanhMuc
        public ActionResult Index()
        {
            var DanhMucRepo = new DanhMucRepository();
            var model = DanhMucRepo.ListAll();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        
    }
}