using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEscola.Controllers
{
    public class LogController : Controller
    {

        private static List<String> data = new List<String>();

        public static void log(string message)
        {
            data.Add(message);
        }

        public ActionResult Index()
        {
            return View(data);
        }
    }
}