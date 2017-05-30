using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DnD_Deutschland.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Requirements()
        {
            return View();
        }

        public IActionResult Locations()
        {
            return View();
        }

        public IActionResult Information()
        {
            return View();
        }
    }
}