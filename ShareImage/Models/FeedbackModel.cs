using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShareImage.Models
{
    public class FeedbackModel
    {
        [Key]
        public int FeedbackID { get; set; }

        [Display(Name = "Tên phản hồi")]
        [Required(ErrorMessage = "Chưa nhập tên phản hồi!")]
        public string Name { get; set; }

        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Chưa nhập nội dung phản hồi!")]
        public string Content { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Chưa nhập số điện thoại!")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Chưa nhập Email!")]
        public string Email { get; set; }

        public DateTime CreateDate { get; set; }

        public int UserID { get; set; }
    }
}