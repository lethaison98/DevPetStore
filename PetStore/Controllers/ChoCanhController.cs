using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class ChoCanhController : Controller
    {
        // GET: ChoCanh
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GiongCho(String Metatitle) 
        {
            var choCanh = new GiongPetRepository().GetGiongPet(Metatitle);
            ViewBag.Item = new PetRepository().ListPetByGiongPetMetatitle(Metatitle);
            return View(choCanh);
        }
    }
}