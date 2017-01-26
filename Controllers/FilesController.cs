using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab2.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            string[] files = Directory.GetFiles(Server.MapPath("~/TextFiles"));
            return View(files);
        }

        public ActionResult Content(string id)
        {
            string fileName = id;
            string[] files = Directory.GetFiles(Server.MapPath("~/TextFiles"));
            foreach (string file in files)
            {
                if (Path.GetFileNameWithoutExtension(file) == fileName)
                {
                    string filePath = file;
                    string fileContents = System.IO.File.ReadAllText(filePath);
                    return View((object)fileContents);
                }
            }
            return View((object)"Cant find file contents");
        }
    }
}