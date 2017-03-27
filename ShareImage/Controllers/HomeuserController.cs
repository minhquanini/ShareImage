using Model.Dao;
using Model.EF;
using ShareImage.Models;
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

            //var model = db.Posts.ToList();
            List<PostViewModel> model =new List<PostViewModel>();

            var q = (from a in db.Posts
                     join b in db.Users on a.UserID equals b.UserID 
                     //from rt in t.DefaultIfEmpty()
                     select new
                     {
                         postID=a.PostID,
                         title=a.Title,
                         description=a.Description,
                         createDate=a.CreateDate,
                         picture=a.Picture,
                         username=b.Username,
                     }).ToList();
            foreach (var item in q)
            {
                model.Add(new PostViewModel()
                {
                    PostID = item.postID,
                    Title=item.title,
                    Description=item.description,
                    Picture=item.picture,
                    CreateDate=item.createDate,
                    Username=item.username,
                });
            }

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