using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedya.Restaurantly.Context;

namespace AcunMedya.Restaurantly.Controllers
{
    public class CategoryController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = Db.Categories.ToList();
            return View(value);
        }
    }
}