using FileWorxMVC.FileWorxActions;
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
        public ActionResult PostLogin(Login login)
        {
            if (LoginActions.Validation(login))
            {
                return RedirectToAction("LoadObjects", "MainPage"); 
            }
            ViewBag.validation = "false";
            return View("GetLogin");
        }
    }
}