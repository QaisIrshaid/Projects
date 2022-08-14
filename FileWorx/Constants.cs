using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileWorx
{
    public static class Constants
    {
        //removing /bin/Debug path to get to FileWorx Folder.
        private static string GetDirectory_ = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString();
        public static string GetDirectory { get => GetDirectory_; set => GetDirectory_ = value; }
       
     
        private static string ComplexSeparator_="%%$$##";
        public static string ComplexSeparator { get => ComplexSeparator_; set => ComplexSeparator_ = value; }


        private static string NewsFlag_ = "newsFlag";
        public static string NewsFlag { get=> NewsFlag_; set=> NewsFlag_=value; }


        private static string PhotoFlag_ = "newsFlag";
        public static string PhotoFlag { get => PhotoFlag_; set => PhotoFlag_ = value; }

       
    }
}
