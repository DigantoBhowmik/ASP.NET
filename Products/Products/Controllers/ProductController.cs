using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Products.Models.Database;

namespace Products.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [HttpGet]
        public ActionResult ProductsList()
        {
            Entities db = new Entities();
            var data = db.Products.ToList();
            return View(data);
        }
    }
}