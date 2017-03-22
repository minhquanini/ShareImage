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
    public class PostController : Controller
    {

        private ShareImageDbContext db = new ShareImageDbContext();
        
        // GET: Post
        [HttpGet]
        public ActionResult UpPost()
        {
            //PostModel model = new PostModel();
            List<Category> l = db.Categories.ToList();
            SelectList SL = new SelectList(l.AsEnumerable(), "CategoryID", "categoryName");
            ViewBag.CatList = SL;
            
            return View();
        }
        
        [HttpPost]
        public ActionResult UpPost(PostModel model, HttpPostedFileBase txtImg)
        {
            var dao = new PostDao();

                    if (ModelState.IsValid)
                {
                if (txtImg != null)
                {
                    
                    txtImg.SaveAs(HttpContext.Server.MapPath("~/Images/")
                                                          + txtImg.FileName);
                    var post = new Post();
                    post.PostID = model.PostID;
                    post.Title = model.Title;
                    post.Description = model.Description;
                    post.CategoryID = model.CategoryID;
                    post.UserID = model.UserID;
                    post.CreateDate = DateTime.Now;
                    model.Picture = txtImg.FileName;
                    var result = dao.Insert(post);
                    if(result>0)
                    {
                        return RedirectToAction("Index", "Homeuser");
                    }
                }
                        else
                {
                    ModelState.AddModelError("", "Đăng ảnh thất bại!");
                }
            }
            return View(model);
            }
            
        }
    }
