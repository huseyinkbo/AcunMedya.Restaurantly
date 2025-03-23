using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;

namespace AcunMedya.Restaurantly.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Index","Login");
            }
            var value = Db.Admins.Find(Session["id"]);
            return View(value);
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var value = Db.Admins.Find(p.AdminId);
            if(value.Password != p.Password)
            {
                ModelState.AddModelError(string.Empty, "Girdiğiniz Şifre Yanlış");
            }
            if (p.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "images\\";
                var fileName = Path.Combine(saveLocation,p.ImageFile.FileName);
                p.ImageFile.SaveAs(fileName);
                value.ImageUrl = "/images/" + p.ImageFile.FileName;
            }
            value.UserName = p.UserName;
            value.Password = p.Password;
            value.Name = p.Name;
            value.SurName = p.SurName;
            value.Email = p.Email;
            Db.SaveChanges();

            return RedirectToAction("Index", "Dashboard");
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
          
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(Admin p)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var value = Db.Admins.Find(Session["id"]);
            if (p.CurrentPassword!=value.Password)
            {
                ModelState.AddModelError("","Mevcut Şifre Hatalı");
                return View(p);
            }
            if (p.NewPassword!=p.ConfirmPassword)
            {
                ModelState.AddModelError("", "Yeni Şifreler Birbirinden Farklı");
                return View(p);
            }
            value.Password = p.NewPassword;
            Db.SaveChanges();
            return RedirectToAction("Index", "Login");
           
        }
    }
}