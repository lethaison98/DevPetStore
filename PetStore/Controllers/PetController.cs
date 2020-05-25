using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class PetController : Controller
    {
        // GET: ChoCanh
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GiongCho(string Metatitle)
        {
            var choCanh = new GiongPetRepository().GetGiongPet(Metatitle);
            ViewBag.Item = new PetRepository().ListPetByGiongPetMetatitle(Metatitle);
            return View(choCanh);
        }
        public ActionResult GiongMeo(string Metatitle)
        {
            var meoCanh = new GiongPetRepository().GetGiongPet(Metatitle);
            ViewBag.Item = new PetRepository().ListPetByGiongPetMetatitle(Metatitle);
            return View(meoCanh);
        }
        public ActionResult Search(string searchString)
        {
            ViewBag.Item = new PetRepository().Search(searchString);
            return View();
        }
    }
}