using Model.Dao;
using Model.EF;
using ShareImage.Common;
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

        //private ShareImageDbContext db = new ShareImageDbContext();
        
        // GET: Post
        [HttpGet]
        public ActionResult UpPost()
        {
            var db = new ShareImageDbContext();
            ViewData["CategoryID"] = new SelectList(db.Categories.ToList(), "CategoryID", "CategoryName");
            //List<Category> l = db.Categories.ToList();
            //SelectList SL = new SelectList(l.AsEnumerable(), "CategoryID", "categoryName");
            //ViewBag.CatList = SL;
            
            return View();
        }
        
        [HttpPost]
        public ActionResult UpPost(Post model, HttpPostedFileBase txtImg)
        {
                var db = new ShareImageDbContext();

                if (ModelState.IsValid)
                {
                if (txtImg != null)
                {
                    
                    //FileInfo fi = new FileInfo(txtImg.FileName);
                    //var user=new User();
                    //txtImg.SaveAs(HttpContext.Server.MapPath("~/Images/")
                      //                                    + txtImg.FileName);
                    var fileName = Path.GetFileName(txtImg.FileName);                                                                           
                    var path=Path.Combine(Server.MapPath("~/Images"), fileName);
                    txtImg.SaveAs(path);
                    path = Url.Content(Path.Combine("~/Images", fileName));
                    var post = new Post();
                    
                    post.PostID = model.PostID;
                    post.Title = model.Title;
                    post.Description = model.Description;
                    post.CategoryID = model.CategoryID;     //Đây là dòng cần lấy CategoryID
                    //Dưới đây là code lấy UserID hiện tại đang đăng nhập.
                    var userSession = new UserLogin();                    
                    userSession = (UserLogin)Session[ShareImage.Common.CommonConstants.USER_SESSION];
                    post.UserID = userSession.UserID;                     
                    post.CreateDate = DateTime.Now;
                    //post.Picture = txtImg.FileName;
                    post.Picture = path;
                    //var result = dao.Insert(post);
                    db.Posts.Add(post);
                    //db.Posts.Add(user);
                    db.SaveChanges();
                    
                    
                        return RedirectToAction("Index", "Homeuser");
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
