using FileWorxMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileWorxMVC.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult GetLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PostLogin()
        {
            var usersDirectory = Server.MapPath("~/Users/");
            string[] entries = Directory.GetFileSystemEntries(usersDirectory);

            for (int i = 0; i < entries.Length; i++)
            {
                string[] file = System.IO.File.ReadAllLines(entries[i]);
                string[] objectAttributes = file[0].Split(new string[] { Constants.ComplexSeparator }, StringSplitOptions.None);
                if (objectAttributes[1] == Request["LoginName"] && objectAttributes[2] == Request["Password"])
                {
                    Constants.LastModifier = objectAttributes[0];
                    Constants.CurrentUserFileName = Path.GetFileName(entries[i]);

                    return RedirectToAction("LoadObjects", "MainPage");
                }
            }
            return View("GetLogin");
        }
    }
}