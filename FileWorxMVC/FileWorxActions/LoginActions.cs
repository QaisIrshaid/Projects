using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using FileWorxMVC.Models;

namespace FileWorxMVC.FileWorxActions
{
    public static class LoginActions
    {
        public static bool Validation(Login login)
        {
            var usersDirectory = System.Web.HttpContext.Current.Server.MapPath(Constants.UsersFolder);
            string[] entries = Directory.GetFileSystemEntries(usersDirectory);

            for (int i = 0; i < entries.Length; i++)
            {
                string[] file = System.IO.File.ReadAllLines(entries[i]);
                string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator }, StringSplitOptions.None);
                if (objectAttributes[1] == login.LoginName && objectAttributes[2] == login.Password)
                {
                    CurrentUser.LastModifier = objectAttributes[0];
                    CurrentUser.FileName = Path.GetFileName(entries[i]);
                    return true;
                }
            }
            return false;
        }
    }
}