using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShareImage.Controllers
{
    public class HomeuserController : Controller
    {
        // GET: Homeuser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            var model = new CategoryDao().ListCategory();
            return PartialView(model);
        }
    }
}