using FileWorxMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileWorxMVC.FileWorxActions
{
    public static class PhotoActions
    {
        public static void PostPhoto(Photo photo)
        {
            string photoPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Photos/"), photo.PhotoName);
            photo.ImageFile.SaveAs(photoPath);
            var fileDirectory = System.Web.HttpContext.Current.Server.MapPath("~/News/" + Guid.NewGuid().ToString() + ".txt");

            var userData = photo.Title + Constants.ComplexSeparator + photo.Description +
            Constants.ComplexSeparator + photo.PhotoName + Constants.ComplexSeparator + photo.LastModifierFileName + Constants.ComplexSeparator +
            photo.PhotoFlag + Constants.ComplexSeparator + photo.Body;

            StreamWriter streamWriter = new StreamWriter(fileDirectory);
            streamWriter.WriteLine(userData);
            streamWriter.Flush();
            streamWriter.Close();
        }

        public static void UpdatePhoto(Photo photo)
        {


            if (photo.PhotoName != null)
            {
                //User Changed the photo, Delete the old photo and save the new one.

                System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(Path.Combine("~", photo.PhotoDirectory)));
                string newPhoto = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Photos/"), photo.PhotoName);
                photo.ImageFile.SaveAs(newPhoto);
            }
            else
            {
                //User didn't change the photo, keep the old photo and assign porprty PhotoName with it's name.

                photo.PhotoName = Path.GetFileName(photo.PhotoDirectory);
            }

            var userData = photo.Title + Constants.ComplexSeparator + photo.Description +
            Constants.ComplexSeparator + photo.PhotoName + Constants.ComplexSeparator + photo.LastModifierFileName + Constants.ComplexSeparator +
            photo.PhotoFlag + Constants.ComplexSeparator + photo.Body;

            var fileDirectory = photo.FileDirectory;
            StreamWriter streamWriter = new StreamWriter(fileDirectory);
            streamWriter.WriteLine(userData);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}