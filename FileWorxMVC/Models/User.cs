using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileWorxMVC.Models
{
    public class User
    {
        public string Name { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string LastModifierFileName {get; set; }
    }
}