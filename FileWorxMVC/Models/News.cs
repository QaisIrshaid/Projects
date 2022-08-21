using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileWorxMVC.Models
{
    public class News
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Body { get; set; }
        public string LastModifierFileName { get; set; }
        public string NewsFlag { get; set; }
        public string FileDirectory { get; set; }

    }
}