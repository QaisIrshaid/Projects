using FileWorxMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FileWorxMVC.FileWorxActions
{
    public static class MainPageActions
    {
        public static List<string[]> LoadObjects()
        {
            var fileDirectory = System.Web.HttpContext.Current.Server.MapPath("~/News/");
            string[] entries = Directory.GetFileSystemEntries(fileDirectory);
            string[] row;
            List<string[]> allObjects = new List<string[]>();

            for (int i = 0; i < entries.Length; i++)
            {
                string[] file = System.IO.File.ReadAllLines(entries[i]);
                string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator }, StringSplitOptions.None);
                FileInfo fileInfo = new FileInfo(entries[i]);
                DateTime date = fileInfo.CreationTime;
                string username = UserActions.GetUsername(objectAttributes[3]);
                //                        Title         Creation Date         Description        Object Index   Last Modifier
                row = new string[] { objectAttributes[0], date.ToString(), objectAttributes[1], i.ToString(), username };
                allObjects.Add(row);
            }
            return allObjects;
        }

        public static string[] LoadSpecificObject(int id)
        {
            var fileDirectory = System.Web.HttpContext.Current.Server.MapPath("~/News/");
            string[] entries = Directory.GetFileSystemEntries(fileDirectory);
            string[] file = System.IO.File.ReadAllLines(entries[id]);
            string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator }, StringSplitOptions.None);
            string body = objectAttributes[5];
            int i = 1;
            while (i < file.Length)
            {
                body += file[i] + "\n";
                i++;
            }

            if (objectAttributes[4] == Constants.NewsFlag)
            {
                //                                 Title               Description           Category        Body       NewsFlag
                string[] row = new string[] { objectAttributes[0], objectAttributes[1], objectAttributes[2], body, objectAttributes[4] };
                return row;
            }

            else
            {               
                //                                 Title               Description                    Photo Directory                  Body       PhotoFlag
                string[] row = new string[] { objectAttributes[0], objectAttributes[1], Path.Combine("/Photos/", objectAttributes[2]), body, objectAttributes[4] };
                return row;
            }
        }

        public static void DeleteObject(int id)
        {
            var fileDirectory = System.Web.HttpContext.Current.Server.MapPath("~/News/");
            string[] entries = Directory.GetFileSystemEntries(fileDirectory);
            string[] file = System.IO.File.ReadAllLines(entries[id]);
            string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator }, StringSplitOptions.None);
            file[0] = null;

            if (objectAttributes[4] == Constants.NewsFlag)
            {
                System.IO.File.Delete(entries[id]);
            }

            else
            {
                var photoFile = System.Web.HttpContext.Current.Server.MapPath("~/Photos/");
                System.IO.File.Delete(Path.Combine(photoFile, objectAttributes[2]));//Delete the photo
                System.IO.File.Delete(entries[id]);//delete the text file
            }
        }

        public static string[] UpdateObject(int id)
        {
            var fileDirectory = System.Web.HttpContext.Current.Server.MapPath("~/News/");
            string[] entries = Directory.GetFileSystemEntries(fileDirectory);
            string[] file = System.IO.File.ReadAllLines(entries[id]);
            string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator }, StringSplitOptions.None);
            string body = objectAttributes[5];
            int i = 1;
            while (i < file.Length)
            {
                body += file[i] + "\n";
                i++;
            }

            if (objectAttributes[4] == Constants.NewsFlag)
            { 
                //                                  Title            Description           Category        Body  /File directory/    Last Modifier               NewsFlag
                string[] row = new string[] { objectAttributes[0], objectAttributes[1], objectAttributes[2], body, entries[id], Constants.CurrentUserFileName, Constants.NewsFlag };
                return (row);
            }

            else
            {
                //                                  Title            Description                           Photo directory             Body /File directory/     Last Modifier               PhotoFlag
                string[] row = new string[] { objectAttributes[0], objectAttributes[1], Path.Combine("/Photos/", objectAttributes[2]), body, entries[id], Constants.CurrentUserFileName, Constants.PhotoFlag };
                return (row);
            }

        }
    }
}