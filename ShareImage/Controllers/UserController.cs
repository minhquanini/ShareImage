using Model.Dao;
using Model.EF;
using ShareImage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ShareImage.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                
                var dao = new UserDao();
                if(dao.CheckUsername(model.Username))
                {
                    ModelState.AddModelError("", "Tài khoản đã tồn tại!");
                }
                else if(dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại!");
                }
                else
                {
                    var user = new User();
                    user.Username = model.Username;
                    user.Password = model.Password;
                    user.Birthday = model.Birthday;
                    user.Fullname = model.Fullname;
                    user.Email = model.Email;
                    user.IsAdmin = model.IsAdmin;

                    user.CreateDate = DateTime.Now;
                    var result = dao.Insert(user);
                    if(result>0)
                    {
                        ViewBag.Success = "Đăng ký thành công!";
                        model = new RegisterModel();
                        //Có thể bỏ cái điều hướng này do có thông báo đăng ký thành công trên Form Đăng ký
                        return RedirectToAction("Index", "Homeuser");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký thất bại!");
                    }
                }
            }
            return View(model);
        }
        
    }
}