using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Database;

namespace WebApplication2.Controllers
{
    public class NewsController : Controller
    {

        // GET: News
        [HttpGet]
        public ActionResult NewsList()
        {
            Entities db = new Entities();
            var data = db.News.ToList(); 
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new News());
        }
        [HttpPost]
        public ActionResult Create(News n)
        {
            if (ModelState.IsValid)
            {
                Entities db = new Entities();
                db.News.Add(n);
                db.SaveChanges();
                return RedirectToAction("NewsList");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Entities db = new Entities();
            var data = (from n in db.News where n.Id == id select n).FirstOrDefault();
            return View(data);
        }
        public ActionResult Edit(News nn)
        {
            if (ModelState.IsValid)
            {
                Entities db = new Entities();
                var data = (from n in db.News where n.Id == nn.Id select n).FirstOrDefault();
                db.Entry(data).CurrentValues.SetValues(nn);
                db.SaveChanges();
                return RedirectToAction("NewsList");
            }
            return View();
        }
    }
}