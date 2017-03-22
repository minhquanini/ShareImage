using Model.Dao;
using Model.EF;
using ShareImage.Common;
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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                 var dao = new UserDao();
                var result = dao.Login(model.Username, model.Password);
                if(result==1)
                {
                    var user = dao.GetByID(model.Username);
                    var userSession = new UserLogin();
                    userSession.UserName = user.Username;
                    userSession.UserID =user.UserID;

                    Session.Add(CommonConstants.USER_SESSION,userSession);

                    return RedirectToAction("Index", "Homeuser");
                }else if(result==0)
                    {
                        ModelState.AddModelError("", "Tên đăng nhập không đúng!");
                    }
                    else if(result==2)
                    {
                     ModelState.AddModelError("","Mật khẩu không đúng");
                    }
                
                }
            return View(model);
            }
            
        
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Index","Homeuser");
        }



        //public ActionResult Post()
        //{
        //    return View();
        //}

        }


    
        
    }
