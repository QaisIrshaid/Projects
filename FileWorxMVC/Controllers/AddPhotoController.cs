using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using FileWorxMVC.Models;
using FileWorxMVC.FileWorxActions;

namespace FileWorxMVC.Controllers
{
    public class AddPhotoController : Controller
    {
        [HttpGet]
        public ActionResult AddNewPhoto()
        {
            return View(new string[] {Constants.CurrentUserFileName, Constants.PhotoFlag});
        }

        [HttpPost]
        public ActionResult PostPhoto( Photo photo)
        {
            PhotoActions.PostPhoto(photo);
            return RedirectToAction("LoadObjects", "MainPage");
        }

        [HttpPost]
        public ActionResult UpdatePhoto(Photo photo)
        {
            PhotoActions.UpdatePhoto(photo);
            return RedirectToAction("LoadObjects", "MainPage");
        }
    }
}