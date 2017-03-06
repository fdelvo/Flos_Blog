using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flos_Blog.Controllers
{
    public class TextController : Controller
    {
        // GET: Text
        public ActionResult Read()
        {
            return View();
        }
    }
}