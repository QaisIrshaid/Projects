using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileWorxMVC.Models
{
    public class Photo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string PhotoName { get; set; }
        public string PhotoDirectory { get; set; }
        public string FileDirectory { get; set; }   
        public HttpPostedFileBase ImageFile { get; set; }  
        public string LastModifierFileName { get; set; }
        public string PhotoFlag { get; set; }
    }
}