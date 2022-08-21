using FileWorxMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileWorxMVC.FileWorxActions
{
    public static class UserActions
    {
        public static bool PostUser(User user)
        {
            var userDirectory = System.Web.HttpContext.Current.Server.MapPath(Constants.UsersFolder + Guid.NewGuid().ToString() + ".txt");

            if (!ValidLoginName(user.LoginName))
            {
                var userData = user.Name + Constants.ComplexSeparator + user.LoginName +
                Constants.ComplexSeparator + user.Password + Constants.ComplexSeparator + user.LastModifierFileName;

                StreamWriter streamWriter = new StreamWriter(userDirectory);
                streamWriter.WriteLine(userData);
                streamWriter.Flush();
                streamWriter.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidLoginName(string loginName)
        {
            bool validLoginName;
            List<string> allUsers = GetAllLoginNames();
            validLoginName = allUsers.Contains(loginName);
            return validLoginName;
        }

        public static List<string[]> ViewUsers()
        {
            string usersDirectory = System.Web.HttpContext.Current.Server.MapPath(Constants.UsersFolder);
            string[] entries = Directory.GetFileSystemEntries(usersDirectory);
            List<string[]> allUsers = new List<string[]>();
            for (int i = 0; i < entries.Length; i++)
            {
                string[] file = System.IO.File.ReadAllLines(entries[i]);
                string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator }, StringSplitOptions.None);
                FileInfo inf = new FileInfo(entries[i]);
                DateTime date = inf.CreationTime;
                string lastModifier = GetUsername(objectAttributes[3]);
                //                                       Name                 LoginName     LastModifier   Creationdate
                string[] userInfo = new string[] { objectAttributes[0], objectAttributes[1], lastModifier, date.ToString() };
                allUsers.Add(userInfo);
            }
            allUsers = allUsers
                        .OrderByDescending(arr => arr[3])
                        .ThenBy(arr => arr[0])
                        .ToList();
            return allUsers;
        }

        public static string[] GetUserInfo()
        {
            string userDirectory = System.Web.HttpContext.Current.Server.MapPath(Constants.UsersFolder);
            string[] entries = Directory.GetFileSystemEntries(userDirectory);
            string[] userInfo = new string[] { };
            for (int i = 0; i < entries.Length; i++)
            {
                if (Path.GetFileName(entries[i]) == CurrentUser.FileName)
                {
                    string[] file = System.IO.File.ReadAllLines(entries[i]);
                    string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator }, StringSplitOptions.None);
                    userInfo = new string[] { objectAttributes[0], objectAttributes[1], objectAttributes[2], objectAttributes[3] };
                }
            }
            return userInfo;
        }

        public static bool PostUserUpdates(User user)
        {
            string userDirectory = System.Web.HttpContext.Current.Server.MapPath(Constants.UsersFolder);
            string[] entries = Directory.GetFileSystemEntries(userDirectory);
            for (int i = 0; i < entries.Length; i++)
            {
                //if the file name match the current user file name.
                if (Path.GetFileName(entries[i]) == CurrentUser.FileName)
                {
                    //if the new login name does not match any other user then accept it.
                    if (!ValidLoginName(user.LoginName))
                    {
                        var userData = user.Name + Constants.ComplexSeparator + user.LoginName +
                        Constants.ComplexSeparator + user.Password + Constants.ComplexSeparator + user.LastModifierFileName;

                        StreamWriter streamWriter = new StreamWriter(entries[i]);
                        streamWriter.WriteLine(userData);
                        streamWriter.Flush();
                        streamWriter.Close();
                        return true;
                    }
                    else 
                    {
                        //if the login name is the same as the current user login name then accept it.
                        if (user.LoginName == GetLoginName(CurrentUser.FileName))
                        {
                            
                            var userData = user.Name + Constants.ComplexSeparator + user.LoginName +
                            Constants.ComplexSeparator + user.Password + Constants.ComplexSeparator + user.LastModifierFileName;

                            StreamWriter streamWriter = new StreamWriter(entries[i]);
                            streamWriter.WriteLine(userData);
                            streamWriter.Flush();
                            streamWriter.Close();
                            return true;
                        }

                        //reject the new login name
                        return false; 
                    }                    
                }
            }
            return false;
        }

        public static string GetUsername(string fileName)
        {
            string userDirectory = System.Web.HttpContext.Current.Server.MapPath(Constants.UsersFolder);
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

        public static string GetLoginName(string fileName)
        {
            string userDirectory = System.Web.HttpContext.Current.Server.MapPath(Constants.UsersFolder);
            string[] entries = Directory.GetFileSystemEntries(userDirectory);
            string loginName = "";
            for (int i = 0; i < entries.Length; i++)
            {
                if (Path.GetFileName(entries[i]) == fileName)
                {
                    string[] file = System.IO.File.ReadAllLines(entries[i]);
                    string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator }, StringSplitOptions.None);
                    loginName = objectAttributes[1];
                }
            }
            return loginName;
        }

        public static List<string> GetAllLoginNames()
        {
            string usersDirectory = System.Web.HttpContext.Current.Server.MapPath(Constants.UsersFolder);
            string[] entries = Directory.GetFileSystemEntries(usersDirectory);
            List<string> allUsers = new List<string>();
            for (int i = 0; i < entries.Length; i++)
            {
                string[] file = System.IO.File.ReadAllLines(entries[i]);
                string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator }, StringSplitOptions.None);
                allUsers.Add(objectAttributes[1]);
            }
            return allUsers;

        }

    }
}