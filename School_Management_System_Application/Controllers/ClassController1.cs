using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School_Management_System_Application.Data;
using School_Management_System_Application.Models;
namespace School_Management_System_Application.Controllers
{
    public class ClassController1 : Controller
    {
        private readonly ApplicationDbContext _db;
        public ClassController1(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var classes = _db.classes.ToList();
            return View(classes);
        }

        public IActionResult AddClass()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddClass(Class c)
        {
            if (ModelState.IsValid)
            {
                _db.classes.Add(c);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(" ", "Some Error Occured");
            }

            return View(c);
        }

        public ActionResult Details(long? id)
        {
            var obj = _db.classes.Where(temp => temp.ClassId == id).FirstOrDefault();
            return View(obj);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _db.classes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Class c)
        {
            if (ModelState.IsValid)
            {
                _db.classes.Update(c);
                _db.SaveChanges();
                return RedirectToAction("Index", "ClassController1");
            }
            return View(c);
        }



        public IActionResult Delete(long id)
        {
            var classes = _db.classes.Where(temp => temp.ClassId == id).FirstOrDefault();
            _db.classes.Remove(classes);
            _db.SaveChanges();
            return RedirectToAction("Index", "ClassController1");
        }


    }
}
