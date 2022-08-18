using FileWorxMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileWorxMVC.FileWorxActions
{
    public static  class UserActions
    {
        public static void PostUser(User user)
        {
            var userDirectory = System.Web.HttpContext.Current.Server.MapPath("~/Users/" + Guid.NewGuid().ToString() + ".txt");

            var userData = user.Name + Constants.ComplexSeparator + user.LoginName +
            Constants.ComplexSeparator + user.Password + Constants.ComplexSeparator + user.LastModifierFileName;

            StreamWriter streamWriter = new StreamWriter(userDirectory);
            streamWriter.WriteLine(userData);
            streamWriter.Flush();
            streamWriter.Close();
        }

        public static List<string[]> ViewUsers()
        {
            string usersDirectory = System.Web.HttpContext.Current.Server.MapPath("~/Users/");
            string[] entries = Directory.GetFileSystemEntries(usersDirectory);
            List<string[]> allUsers = new List<string[]>();
            for (int i = 0; i < entries.Length; i++)
            {
                string[] file = System.IO.File.ReadAllLines(entries[i]);
                string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator }, StringSplitOptions.None);
                FileInfo inf = new FileInfo(entries[i]);
                DateTime date = inf.CreationTime;
                string username = GetUsername(objectAttributes[3]);                
                string[] userInfo = new string[] { objectAttributes[0], objectAttributes[1],username, date.ToString() };
                allUsers.Add(userInfo);
            }
            return allUsers;
        }

        public static string[] GetUserInfo()
        {
            string userDirectory = System.Web.HttpContext.Current.Server.MapPath("~/Users/");
            string[] entries = Directory.GetFileSystemEntries(userDirectory);
            string[] userInfo = new string[] { };
            for (int i = 0; i < entries.Length; i++)
            {
                if (Path.GetFileName(entries[i]) == Constants.CurrentUserFileName)
                {
                    string[] file = System.IO.File.ReadAllLines(entries[i]);
                    string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator }, StringSplitOptions.None);
                    userInfo = new string[] { objectAttributes[0], objectAttributes[1], objectAttributes[2], objectAttributes[3] };
                }
            }
            return userInfo;
        }

        public static void PostUserUpdates(User user)
        {
            string userDirectory = System.Web.HttpContext.Current.Server.MapPath("~/Users/");
            string[] entries = Directory.GetFileSystemEntries(userDirectory);
            for (int i = 0; i < entries.Length; i++)
            {
                if (Path.GetFileName(entries[i]) == Constants.CurrentUserFileName)
                {
                    var userData = user.Name + Constants.ComplexSeparator + user.LoginName +
                     Constants.ComplexSeparator + user.Password + Constants.ComplexSeparator + user.LastModifierFileName;

                    StreamWriter streamWriter = new StreamWriter(entries[i]);
                    streamWriter.WriteLine(userData);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
        }

        public static string GetUsername(string fileName)
        {
            string userDirectory = System.Web.HttpContext.Current.Server.MapPath("~/Users/");
            string[] entries = Directory.GetFileSystemEntries(userDirectory);
            string username = "";
            for (int i = 0; i < entries.Length; i++)
            {
                if (Path.GetFileName(entries[i]) == fileName)
                {
                    string[] file = System.IO.File.ReadAllLines(entries[i]);
                    string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator }, StringSplitOptions.None);
                    username = objectAttributes[0];
                }
            }
            if (username == "")
            {
                username = "Deleted User";
            }
            return username;
        }
    }
}