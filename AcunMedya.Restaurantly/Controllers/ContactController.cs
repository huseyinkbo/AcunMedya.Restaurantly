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
    public class ContactController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = Db.Contacts.ToList();
            return View(value);
        }
        public ActionResult ContactList()
        {
            var value = Db.Contacts.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult ContactCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactCreate(Contact model)
        {
            Db.Contacts.Add(model);
            Db.SaveChanges();
            return RedirectToAction("ContactList");
        }
        [HttpGet]
        public ActionResult ContactEdit(int id)
        {
            var value = Db.Contacts.Find(id);
            return View(value);


        }
        [HttpPost]
        public ActionResult ContactEdit(Contact model)
        {
            var value = Db.Contacts.Find(model.ContactId);
            value.Name = model.Name;
            value.Email = model.Email;
            value.Subject = model.Subject;
            value.Message = model.Message;
            value.IsRead = model.IsRead;
            value.SendDate = model.SendDate;

            Db.SaveChanges();
            return RedirectToAction("ContactList");


        }
        public ActionResult ContactDelete(int id)
        {
            var value = Db.Contacts.Find(id);
            Db.Contacts.Remove(value);
            Db.SaveChanges();
            return RedirectToAction("ContactList");
        }
        public ActionResult Okundu(int id)
        {
            var value = Db.Contacts.Find(id);
            value.IsRead = true;
            Db.SaveChanges();
            return RedirectToAction("ContactList");
        }
        public ActionResult Okunmadi(int id)
        {
            var value = Db.Contacts.Find(id);
            value.IsRead = false;
            Db.SaveChanges();
            return RedirectToAction("ContactList");
        }
    }
}