using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Model.EF;


namespace ShareImage.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index(string searchstring,int page=1,int pageSize=5)
        {
            var dao = new UserDao();

            var model = dao.ListAllPaging(searchstring, page, pageSize);
            ViewBag.searchstring = searchstring;
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            var user = new UserDao().ViewDetail(id);
            //SetViewBag(user.IsAdmin);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa thất bại!");
                }
            }
            //SetViewBag(user.IsAdmin);
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int userid)
        {
            new UserDao().Delete(userid);
            return RedirectToAction("Index");
        }


        public ActionResult ListFB(int page = 1, int pageSize = 5)
        {
            var dao = new FeedbackDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
    }
}