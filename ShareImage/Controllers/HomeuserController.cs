using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
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
            var db = new ShareImageDbContext();

            var model = db.Posts.ToList();

            return View(model);
            //return View(q.OrderBy(x => x.CreateDate).ToList());
         }

        //public IQueryable<User> GetUser()
        //{
        //     var db = new ShareImageDbContext();
        //     return from a in db.Posts
        //            join b in db.Users on a.UserID equals b.UserID  
        //            select new
        //            {
        //                b.Username
        //            };

        //}

        public ActionResult Menu()
        {
            var model = new CategoryDao().ListCategory();
            return PartialView(model);
        }
    }
}