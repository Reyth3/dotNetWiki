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
    }
}