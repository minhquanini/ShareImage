using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareImage.Common
{
    [Serializable]
    public class UserLogin
    { 
        public int AccountID { set; get; }
        public string UserName { set; get; }
    }
}