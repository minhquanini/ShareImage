using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShareImage.Models
{
    public class RegisterModel
    {
        [Key]
        public int UserID { set; get; }

        [Display(Name="Tên đăng nhập")]
        [Required(ErrorMessage="Chưa nhập tên đăng nhập!")]
        public string Username { set; get; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Chưa nhập mật khậu!")]
        public string Password { set; get; }
        
        [Display(Name="Xác nhận mật khẩu")]
        //[Required(ErrorMessage = "Chưa nhập tên đăng nhập!")]
        [Compare("Password",ErrorMessage="Xác nhận mật khẩu sai!")]
        public string ConfirmPassword { set; get; }

        [Display(Name = "Họ Tên")]
        [Required(ErrorMessage = "Chưa nhập Tên")]
        public string Fullname { set; get; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Chưa nhập ngày sinh")]
        public DateTime Birthday { set; get; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Chưa nhập Email")]
        public string Email { set; get; }

        [Display(Name = "Có là admin không?")]
        [Required(ErrorMessage = "Chưa chọn")]
        public int IsAdmin { set; get; }
    }
}