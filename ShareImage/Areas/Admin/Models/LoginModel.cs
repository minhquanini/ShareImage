using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShareImage.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Nhập vào User Name")]
        public string Username { set; get; }

        [Required(ErrorMessage="Nhập vào PassWord")]
        public string Password { set; get; }
            
        public bool RememberMe { set; get; }

    }
}