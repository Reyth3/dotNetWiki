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
        public ActionResult Index(string name)
        {
            var context = new WikiContext();
            List<Page> pages = null;
            if (name == null)
                pages = context.Pages.ToList();
            else pages = context.Pages.Where(o => o.Name == name).ToList();
            return View(pages);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit()
        {
            var title = Request["title"];
            var category = Request["category"];
            var content = Request["content"];

            Page page = null;
            if(content != null && title != null && category != null)
            {
                page = new Page()
                {
                    Name = title,
                    Category = category,
                    Text = content,
                    Edits = new List<EditData>()
                    {
                        new EditData() { Owner = page, Description = "Page Created", Time = DateTime.UtcNow }
                    }
                };
                try
                {
                    var wc = new WikiContext();
                    wc.Pages.Add(page);
                    wc.SaveChanges();
                } catch { page = null; }
            }
            return View(page);
        }

        public ActionResult Show(int id)
        {
            var page = new WikiContext().Pages.Where(o => o.Id == id).FirstOrDefault();
            return View(page);
        }
    }
}