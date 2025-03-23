using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;

namespace AcunMedya.Restaurantly.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Events.ToList();
            return View(value);
        }
        public ActionResult EventList()
        {
            var value = db.Events.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult EventCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EventCreate(Event model)
        {
            db.Events.Add(model);
            db.SaveChanges();
            return RedirectToAction("EventList");
        }
        [HttpGet]
        public ActionResult EventEdit(int id)
        {
            var value = db.Events.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EventEdit(Event model)
        {
            var value = db.Events.Find(model.EventId);
    
            value.ImageUrl = model.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("EventList");
        }
        public ActionResult EventDelete(int id)
        {
            var value = db.Events.Find(id);
            db.Events.Remove(value);
            db.SaveChanges();
            return RedirectToAction("EventList");
        }
    }
}