using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileWorxMVC.Models
{
    public class CurrentUser
    {
        private static string LastModifier_;
        public static string LastModifier { get => LastModifier_; set => LastModifier_ = value; }

        private static string FileName_;
        public static string FileName { get => FileName_; set => FileName_ = value; }
    }
}