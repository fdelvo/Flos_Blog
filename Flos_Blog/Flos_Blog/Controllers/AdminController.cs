using System.Web.Mvc;

namespace Flos_Blog.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }            public
            ActionResult Edit 
            ()
            {
                return View();
            }
        }
    }