using dotNetWiki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dotNetWiki.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var categories = new WikiContext().Pages.GroupBy(o => o.Category).ToList();
            return View(categories);
        }

        public ActionResult Show(string id)
        {
            var cat = new WikiContext().Pages.Where(o => o.Category == id).ToList();
            ViewBag.Title = id;
            return View(cat);
        }
    }
}