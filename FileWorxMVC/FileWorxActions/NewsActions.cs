using FileWorxMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileWorxMVC.FileWorxActions
{
    public static class NewsActions
    {
        public static void PostNews(News news)
        {
            var userData = news.Title + Constants.ComplexSeparator + news.Description +
            Constants.ComplexSeparator + news.Category + Constants.ComplexSeparator + news.LastModifierFileName + Constants.ComplexSeparator +
            news.NewsFlag + Constants.ComplexSeparator + news.Body;

            if (news.FileDirectory == null)
            {
                news.FileDirectory = System.Web.HttpContext.Current.Server.MapPath(Constants.NewsFolder + Guid.NewGuid().ToString() + ".txt");
            }

            StreamWriter streamWriter = new StreamWriter(news.FileDirectory);
            streamWriter.WriteLine(userData);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}