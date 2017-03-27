using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ShareImage.Models
{
    public class PostModel
    {
        [Key]
        public int PostID { set; get; }

        [Display(Name="Tiêu đề")]
        [Required(ErrorMessage="Chưa nhập tiêu đề")]
        public string Title { set; get; }

        [Display(Name = "Mô tả")]
        public string Description { set; get; }

        [Display(Name = "Hình ảnh")]
        [Required(ErrorMessage = "Chưa chọn ảnh")]
        public string Picture { set; get; }

        public int CategoryID { get; set; }

        public int UserID { get; set; }

        
        //public IEnumerable<SelectListItem> CategoryName { get; set; }

        /*
        [Display(Name = "Loại ảnh")]
        [Required(ErrorMessage = "Chưa chọn loại ãnh")]
        [ForeignKey("CategoryID")]
        public virtual Category CategoryName { set; get; }//Sử dụng join bảng để lấy CategoryName từ CategoryID
        */
         
        public DateTime CreateDate { set; get; }
        //[NotMapped]
        //public HttpPostedFileBase Picture { get; set; }
    }
}