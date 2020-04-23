using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class GiongPetController : Controller
    {
        // GET: GiongPet
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult ThuCungCategory()
        {
            var model = new GiongPetRepository().ListAll();
            return PartialView(model);
        }
    }
}