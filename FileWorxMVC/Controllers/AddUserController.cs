using FileWorxMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using FileWorxMVC.FileWorxActions;

namespace FileWorxMVC.Controllers
{
    public class AddUserController : Controller
    {
        [HttpGet]
        public ActionResult AddNewUser()
        {
            return View(new string[] { CurrentUser.FileName });
        }

        [HttpPost]
        public ActionResult PostUser(User user)
        {
            UserActions.PostUser(user);
            return RedirectToAction("LoadObjects", "MainPage");
        }

        public ActionResult ViewUsers()
        {         
            return View(UserActions.ViewUsers());
        }

        [HttpGet]
        public ActionResult GetUserInfo()
        {           
            return View(UserActions.GetUserInfo());
        }

        [HttpPost]
        public ActionResult PostUserUpdates(User user)
        {
            UserActions.PostUserUpdates(user);
            return RedirectToAction("LoadObjects", "MainPage");
        }
    }
}