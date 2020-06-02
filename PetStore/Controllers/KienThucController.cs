using Model.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class KienThucController : Controller
    {
        // GET: KienThuc
        public ActionResult Index(String searchString, int page = 1, int pagesize = 10)
        {
            var BaiVietRepo = new BaiVietRepository();
            var baiViet = BaiVietRepo.ListAllPaging("", page, pagesize);
            return View(baiViet);
        }
        public ActionResult ChiTiet(string Metatitle)
        {
            var baiViet = new BaiVietRepository().GetBaiViet(Metatitle);
            return View(baiViet);
        }
    }
}