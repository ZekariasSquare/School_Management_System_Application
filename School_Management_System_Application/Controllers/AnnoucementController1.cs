using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using School_Management_System_Application.Data;
using School_Management_System_Application.Models;

namespace School_Management_System_Application.Controllers
{
    public class AnnoucementController1 : Controller
    {
        private readonly ApplicationDbContext _db;
        public AnnoucementController1(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var Annoucement = _db.Annoucements.ToList();
            return View(Annoucement);
        }

        public IActionResult AnnoucementViewParent()
        {
            var Annoucement = _db.Annoucements.ToList();
            return View(Annoucement);
        }
        public IActionResult AnnoucementViewStudent()
        {
            var Annoucement = _db.Annoucements.ToList();
            return View(Annoucement);
        }
        public IActionResult AnnoucementViewTeacher()
        {
            var Annoucement = _db.Annoucements.ToList();
            return View(Annoucement);
        }

        public ActionResult PostAnnoucement()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostAnnoucement(Annoucement s)
        {
            if (ModelState.IsValid)
            {
                _db.Annoucements.Add(s);
                _db.SaveChanges();
                return RedirectToAction("Index", "AnnoucementController1");
            }
            else
            {
                ModelState.AddModelError("", "Some Error Occured");
            }
            return View(s);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _db.Annoucements.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Annoucement c)
        {
            if (ModelState.IsValid)
            {
                _db.Annoucements.Update(c);
                _db.SaveChanges();
                return RedirectToAction("Index", "AnnoucementController1");
            }
            return View(c);
        }

        public ActionResult Delete(int? id)
        {
            var annouement = _db.Annoucements.Where(temp => temp.Id == id).FirstOrDefault();
            _db.Annoucements.Remove(annouement);
            _db.SaveChanges();
            return RedirectToAction("Index", "AnnoucementController1");
        }



        public ActionResult Details(int? id)
        {
            var obj = _db.Annoucements.Where(temp => temp.Id == id).FirstOrDefault();
            return View(obj);
        }
    }
}
