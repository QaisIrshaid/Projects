using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using FileWorxMVC.Models;
using FileWorxMVC.FileWorxActions;

namespace FileWorxMVC.Controllers
{
    public class AddNewsController : Controller
    {
        [HttpGet]
        public ActionResult AddNewNews()
        {
            return View(new string[] {Constants.NewsFlag,Constants.CurrentUserFileName});
        }

        [HttpPost]
        public ActionResult PostNews(News news)
        {
            NewsActions.PostNews(news);
            return RedirectToAction("LoadObjects", "MainPage");
        }

  
    }
}