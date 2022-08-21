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
            if (UserActions.PostUser(user))
            {
                return RedirectToAction("LoadObjects", "MainPage");
            }
            ViewBag.validation = "false";
            return View("AddNewUser", new string[] { CurrentUser.FileName });
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
            if (UserActions.PostUserUpdates(user))
            {
                return RedirectToAction("LoadObjects", "MainPage");
            }
            ViewBag.validation = "false";
            return View("GetUserInfo",UserActions.GetUserInfo());
        }
    }
}