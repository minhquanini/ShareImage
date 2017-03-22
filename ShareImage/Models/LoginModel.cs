using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShareImage.Models
{
    public class LoginModel
    {
        [Key]
        [Display(Name="Tên đăng nhập")]
        [Required(ErrorMessage="Nhập vào tài khoản!")]
        public string Username { set; get; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Nhập vào mật khẩu!")]
        public string Password { set; get; }
    }
}