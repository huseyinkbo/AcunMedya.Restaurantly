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
    public class ReservationController : Controller
    {
       
        RestaurantlyContext Db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = Db.Reservations.ToList();
            return View(value);
        }
        public ActionResult ReservationList()
        {
            var value = Db.Reservations.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult ReservationCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ReservationCreate(Reservation model)
        {
            Db.Reservations.Add(model);
            Db.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        [HttpGet]
        public ActionResult ReservationEdit(int id)
        {
            var value = Db.Reservations.Find(id);
            return View(value);


        }
        [HttpPost]
        public ActionResult ReservationEdit(Reservation model)
        {
            var value = Db.Reservations.Find(model.ReservationId);
            value.Name = model.Name;
            value.Email = model.Email;
            value.Phone = model.Phone;
            value.Description = model.Description;
            value.ReservationDate = model.ReservationDate;
            value.Time = model.Time;
            value.GuestCount = model.GuestCount;
            value.ReservationStatus = model.ReservationStatus;

            Db.SaveChanges();
            return RedirectToAction("ReservationList");


        }
        public ActionResult ReservationDelete(int id)
        {
            var value = Db.Reservations.Find(id);
            Db.Reservations.Remove(value);
            Db.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        public ActionResult ReservationOnayla(int id)
        {
            var value = Db.Reservations.Find(id);
            value.ReservationStatus = "Onaylandı";
            Db.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        public ActionResult ReservationBekleme(int id)
        {
            var value = Db.Reservations.Find(id);
            value.ReservationStatus = "Beklemede";
            Db.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        public ActionResult ReservationRed(int id)
        {
            var value = Db.Reservations.Find(id);
            value.ReservationStatus = "İptal Edildi";
            Db.SaveChanges();
            return RedirectToAction("ReservationList");
        }
    }
}