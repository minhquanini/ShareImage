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
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult Feedback()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Feedback(FeedbackModel model)
        {
            if (ModelState.IsValid)
            {
                
                var dao = new FeedbackDao();
                var fb = new Feedback();

                fb.Name = model.Name;
                fb.Content = model.Content;
                fb.Phone = model.Phone;
                fb.Email = model.Email;
                fb.CreateDate = DateTime.Now;

                fb.UserID = model.UserID;

                var result = dao.Insert(fb);
                if(result>0)
                {
                    model = new FeedbackModel();
                        ViewBag.Success = "Gửi phản hồi thành công!";
                        
                        return RedirectToAction("Index", "Homeuser");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Gửi phản hồi thất bại thất bại!");
                    }
                
                 }

            return View(model);
        }
    }
}