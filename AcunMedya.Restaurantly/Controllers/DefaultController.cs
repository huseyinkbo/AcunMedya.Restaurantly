using System;
using System.Linq;
using System.Web.Mvc;
using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;


namespace AcunMedya.Restaurantly.Controllers
{

    public class DefaultController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead() 
        {
            return PartialView();
        }
        public PartialViewResult PartialTop()
        {
            ViewBag.Call = db.Adress.Select(x => x.Call).FirstOrDefault();
            ViewBag.OpenHours = db.Adress.Select(x=>x.OpenHours).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialNavbar() 
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature() 
        {
            ViewBag.Subtitle = db.Features.Select(x => x.SubTitle).FirstOrDefault();
            ViewBag.Title = db.Features.Select(x => x.Title).FirstOrDefault();
            ViewBag.VideoUrl = db.Features.Select(x => x.VideoUrl).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialAbout()
        {
            ViewBag.Title = db.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.Description = db.Abouts.Select(x => x.Description).FirstOrDefault();
            ViewBag.ImageUrl = db.Abouts.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialService()
        {
            var value = db.Services.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialMenu()
        {
            var value = db.Products.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialContact()
        {           
            return PartialView();
        }
        [HttpPost]
        public ActionResult ContactAdd(Contact model) 
        {
            model.SendDate = DateTime.Now;
            model.IsRead = false;
            db.Contacts.Add(model);
            db.SaveChanges();
            ViewBag.Message = "Mesaj Başarılı";
            return View("Index");
        }
        public PartialViewResult PartialSpecials()
        {
            var value = db.Specials.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialBookaTable()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult BookaTableAdd(Reservation model)
        {
            model.ReservationDate = DateTime.Now;
            model.ReservationStatus = "Başarılı";
            db.Reservations.Add(model);
            db.SaveChanges();
            ViewBag.Message = "Rezervasyon Başarılı";
            return View("Index");
        }
        public PartialViewResult PartialTestimonial()
        {
            var value = db.Testimonials.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialChefs()
        {
            var value = db.Chefs.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialAdress()
        {
            ViewBag.Location = db.Adress.Select(x => x.Location).FirstOrDefault();
            ViewBag.OpenHours = db.Adress.Select(x => x.OpenHours).FirstOrDefault();
            ViewBag.Email = db.Adress.Select(x => x.Email).FirstOrDefault();
            ViewBag.Call = db.Adress.Select(x => x.Call).FirstOrDefault();
            return PartialView();
        }
    }
}