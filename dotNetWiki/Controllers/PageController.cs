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
            var page = new Models.Page();
            return View(page);
        }

        [HttpPost]
        public ActionResult Submit()
        {
            var title = Request["title"];
            var category = Request["category"];
            var content = Request["content"];
            var id = 0;
            int.TryParse(Request["pId"], out id);

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
                    if(id == 0)
                        wc.Pages.Add(page);
                    else
                    {
                        var p = wc.Pages.First(o => o.Id == id);
                        p.Name = title;
                        p.Text = content;
                        p.Category = category;
                        p.Edits.Add(new EditData() { Owner = p, Time = DateTime.UtcNow, Description = Request["edit"] });
                        page = p;
                    }
                    wc.SaveChanges();
                } catch { page = null; }
            }
            return View(page);
        }

        public ActionResult Show(int id)
        {
            var page = new WikiContext().Pages.Where(o => o.Id == id).FirstOrDefault();
            if (page != null)
                ViewBag.Title = page.Name;
            else ViewBag.Title = "Error";
            return View(page);
        }

        public ActionResult Edit(int id)
        {
            var page = new WikiContext().Pages.FirstOrDefault(o => o.Id == id);
            return View(page);
        }
    }
}