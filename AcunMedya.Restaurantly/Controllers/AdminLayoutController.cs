using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedya.Restaurantly.Context;

namespace AcunMedya.Restaurantly.Controllers
{
    public class AdminLayoutController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
         
        // GET: AdminLayout
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();

        }
        public PartialViewResult PartialNavbar()
        {
            var messages = Db.Contacts.Where(x => x.IsRead == false).ToList();
            var values = Db.Notifications.Where(x => x.IsRead == false).ToList();           
            ViewBag.notificationCountOkunmadi = Db.Notifications.Where(x => x.IsRead == false).Count();
            ViewBag.messages = messages;
            ViewBag.notReadMessageCount = Db.Contacts.Where(x => x.IsRead == false).Count();
            return PartialView(values);
        }
        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public ActionResult NotificationStatusChangeToTrue(int id)
        {
            var value = Db.Notifications.Find(id);
            value.IsRead = true;
            Db.SaveChanges();
            return RedirectToAction("Contact", "ContactList");
        }

        public ActionResult MessageStatusChangeToTrue(int id)
        {
            var value = Db.Contacts.Find(id);
            value.IsRead = true;
            Db.SaveChanges();
            return RedirectToAction("Contact", "ContactList");
        }
    }
}