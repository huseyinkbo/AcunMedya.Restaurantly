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
        public class GalleryController : Controller
        {
            RestaurantlyContext db = new RestaurantlyContext();
            public ActionResult Index()
            {
                var value = db.Gallerys.ToList();
                return View(value);
            }
            public ActionResult GalleryList()
            {
                var value = db.Gallerys.ToList();
                return View(value);
            }
            [HttpGet]
            public ActionResult GalleryCreate()
            {
                return View();
            }
            [HttpPost]
            public ActionResult GalleryCreate(Gallery model)
            {
                db.Gallerys.Add(model);
                db.SaveChanges();
                return RedirectToAction("GalleryList");
            }
            [HttpGet]
            public ActionResult GalleryEdit(int id)
            {
                var value = db.Gallerys.Find(id);
                return View(value);
            }
            [HttpPost]
            public ActionResult GalleryEdit(Gallery model)
            {
                var value = db.Gallerys.Find(model.GalleryId);
                value.ImageUrl = model.ImageUrl;
                db.SaveChanges();
                return RedirectToAction("GalleryList");
            }
            public ActionResult GalleryDelete(int id)
            {
                var value = db.Gallerys.Find(id);
                db.Gallerys.Remove(value);
                db.SaveChanges();
                return RedirectToAction("GalleryList");
            }
        }
    }
