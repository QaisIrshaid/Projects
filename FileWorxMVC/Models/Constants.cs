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

        private static string NewsFolder_="~/News/";
        public static string NewsFolder { get => NewsFolder_; set => NewsFolder_=value; }

        private static string PhotosFolder_ = "~/Photos/";
        public static string PhotosFolder { get => PhotosFolder_; set => PhotosFolder_ = value; }

        private static string UsersFolder_ = "~/Users/";
        public static string UsersFolder { get => UsersFolder_; set => UsersFolder_ = value; }

    }
}