﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareImage.Models
{
    public class PostViewModel
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public DateTime CreateDate { get; set; }
        public string Username { get; set; }
        public string CategoryID { get; set; }
    }
}
