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
    public class AdressController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Adress.ToList();
            return View(value);
        }
        public ActionResult AdressList()
        {
            var value = db.Adress.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AdressCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdressCreate(Adress model)
        {
            db.Adress.Add(model);
            db.SaveChanges();
            return RedirectToAction("AdressList");
        }
        [HttpGet]
        public ActionResult AdressEdit(int id)
        {
            var value = db.Adress.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult AdressEdit(Adress model)
        {
            var value = db.Adress.Find(model.AdressId);
            value.Location = model.Location;
            value.OpenHours = model.OpenHours;
            value.Email = model.Email;
            value.Call = model.Call;
            db.SaveChanges();
            return RedirectToAction("AdressList");
        }
        public ActionResult AdressDelete(int id)
        {
            var value = db.Adress.Find(id);
            db.Adress.Remove(value);
            db.SaveChanges();
            return RedirectToAction("AdressList");
        }
    }
}