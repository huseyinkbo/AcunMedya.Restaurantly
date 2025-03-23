using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedya.Restaurantly.Context;

namespace AcunMedya.Restaurantly.Controllers
{
    public class StatisticController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        public ActionResult Index()
        {
            ViewBag.categoryCount = Db.Categories.Count();
            ViewBag.serviceCount = Db.Services.Count();
            ViewBag.eventCount = Db.Events.Count();
            ViewBag.chefCount = Db.Chefs.Count();
            ViewBag.contactCount = Db.Contacts.Count();
            ViewBag.testimonialCount = Db.Testimonials.Count();
            ViewBag.notificationCount = Db.Notifications.Count();       
            ViewBag.productCount = Db.Products.Count();
            ViewBag.reservationCount = Db.Reservations.Count();
            ViewBag.specialCount = Db.Specials.Count();
            ViewBag.galleryCount = Db.Gallerys.Count();
            ViewBag.adminCount = Db.Admins.Count();
        
        
        
            return View();
        }
    }
}