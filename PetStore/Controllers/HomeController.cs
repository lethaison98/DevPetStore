using Model.Repository;
using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SetViewBag();
            return View();
        }
        public ActionResult PageNotFound()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult _SessionHeader()
        {
            var cart = Session[Common.CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public void SetViewBag()
        {
            ViewBag.Slide = new SlideRepository().ListAll();
            ViewBag.HotDeal = new HotDealRepository().ListAll();
        }
    }
}