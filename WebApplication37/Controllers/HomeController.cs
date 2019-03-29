using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication37.DAL;

namespace WebApplication37.Controllers
{
    public class HomeController : Controller
    {         
             
        // GET: Home
        public ActionResult Index()
        {
            BlogContext context = new BlogContext();
            context.Entries.ToList();
            return View();
        }
    }
}