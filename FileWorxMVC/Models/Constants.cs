using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileWorxMVC.Models
{
    public static class Constants
    {
        private static string ComplexSeparator_ = "%%$$##";
        public static string ComplexSeparator { get => ComplexSeparator_; set => ComplexSeparator_ = value; }


        private static string NewsFlag_ = "newsFlag";
        public static string NewsFlag { get => NewsFlag_; set => NewsFlag_ = value; }


        private static string PhotoFlag_ = "photoFlag";
        public static string PhotoFlag { get => PhotoFlag_; set => PhotoFlag_ = value; }

        private static string LastModifier_;
        public static string LastModifier { get => LastModifier_; set => LastModifier_ = value; }

        private static string CurrentUserFileName_;
        public static string CurrentUserFileName { get => CurrentUserFileName_; set => CurrentUserFileName_ = value; }


    }
}