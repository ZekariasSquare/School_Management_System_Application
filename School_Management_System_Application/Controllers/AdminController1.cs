using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using School_Management_System_Application.Data;
using School_Management_System_Application.Models;

namespace School_Management_System_Application.Controllers
{
    public class AdminController1 : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdminController1(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var Admin = _db.admins.ToList();
            return View(Admin);
        }

        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin s)
        {
            if (ModelState.IsValid)
            {
                _db.admins.Add(s);
                _db.SaveChanges();
                return RedirectToAction("Welcome", "AdminController1");
            }
            else
            {
                ModelState.AddModelError("", "Some Error Occured");
            }
            return View(s);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin s)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = _db)
                {
                    var obj = db.admins.Where(temp => temp.Username.Equals(s.Username) && temp.password.Equals(s.password)).FirstOrDefault();
                    if (obj == null)
                    {

                        ModelState.AddModelError("", "You are not registered as an adminstrator,please fill the sign-up carefully !!! ");
                    }
                    else
                    {
                        return RedirectToAction("Welcome", "AdminController1");
                    }

                }
            }
            return View();
        }

        public IActionResult Welcome()
        {

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _db.admins.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Admin c)
        {
            if (ModelState.IsValid)
            {
                _db.admins.Update(c);
                _db.SaveChanges();
                return RedirectToAction("Index", "AdminController1");
            }
            return View(c);
        }


        public ActionResult Delete(long id)
        {
            var admin = _db.admins.Where(temp => temp.AId == id).FirstOrDefault();
            _db.admins.Remove(admin);
            _db.SaveChanges();
            return RedirectToAction("Index", "AdminController1");
        }
    }
}
