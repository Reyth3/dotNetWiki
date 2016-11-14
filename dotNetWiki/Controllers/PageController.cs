using dotNetWiki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dotNetWiki.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Index()
        {
            var context = new WikiContext();
            var pages = context.Pages.ToList();
            return View(pages);
        }

        public ActionResult Create()
        {

            return View();
        }
    }
}