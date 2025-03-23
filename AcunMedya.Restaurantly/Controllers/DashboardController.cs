using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedya.Restaurantly.Context;

namespace AcunMedya.Restaurantly.Controllers
{
    public class DashboardController : Controller
    {
      RestaurantlyContext Db = new RestaurantlyContext();
        public ActionResult Index()
        {
            ViewBag.ProductCount = Db.Products.Count();
            ViewBag.CategoryCount = Db.Categories.Count();
            ViewBag.ChefCount = Db.Chefs.Count();
            ViewBag.SpecialCount = Db.Specials.Count();
            return View();
        }
        public PartialViewResult ReservationPartial() 
        {
            var value = Db.Reservations.ToList();
            return PartialView(value);
        }
        public PartialViewResult TestimonialPartial()
        {
            var value = Db.Testimonials.ToList();
            return PartialView(value);
        }
    }
}