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
    public class MainPageController : Controller
    {
        
        public ActionResult LoadObjects()
        {            
            return View(MainPageActions.LoadObjects());           
        }

        public ActionResult LoadSpecificObject(int id)
        {
            string[] obj = MainPageActions.LoadSpecificObject(id);
            if (obj[4] == Constants.NewsFlag)
            {
                return View("LoadNewsObject", obj);
            }
            else
            {
                return View("LoadPhotoObject", obj);
            }
        }

        public ActionResult DeleteObject(int id)
        {
            MainPageActions.DeleteObject(id);
            return RedirectToAction("LoadObjects");
        }

        public ActionResult UpdateObject(int id)
        {
            string[] obj = MainPageActions.UpdateObject(id);
            if (obj[6] == Constants.NewsFlag)
            {
                return View("UpdateNewsObject", obj);
            }
            else
            {
                return View("UpdatePhotoObject", obj);
            }
        }

    }
}