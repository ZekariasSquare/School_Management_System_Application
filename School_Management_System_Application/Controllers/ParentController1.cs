using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using School_Management_System_Application.Data;
using School_Management_System_Application.Models;


namespace School_Management_System_Application.Controllers
{
    public class ParentController1 : Controller
    {
        private readonly ApplicationDbContext _db;
        public ParentController1(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var ListTeacher = _db.Parents.ToList();
            return View(ListTeacher);
        }

        public ActionResult Addparent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Addparent(Parent s)
        {
            if (ModelState.IsValid)
            {
                _db.Parents.Add(s);
                _db.SaveChanges();
                return RedirectToAction("Index", "ParentController1");
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
        public ActionResult Login(Parent s)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = _db)
                {
                    var obj = db.Parents.Where(temp => temp.Email.Equals(s.Email) && temp.password.Equals(s.password)).FirstOrDefault();
                    if (obj == null)
                    {
                        ModelState.AddModelError("", "You are not registerd !!! please contact the registeral office");
                    }
                    else
                    {
                        return RedirectToAction("Welcome", "ParentController1");
                    }

                }
            }
            return View();
        }


       

        public IActionResult Welcome()
        {

            return View();
        }

        //GET-Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _db.Parents.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Parent c)
        {
            if (ModelState.IsValid)
            {
                _db.Parents.Update(c);
                _db.SaveChanges();
                return RedirectToAction("Index", "ParentController1");
            }
            return View(c);
        }


        public ActionResult Delete(int? id)
        {
            var parent = _db.Parents.Where(temp => temp.ParentId == id).FirstOrDefault();
            _db.Parents.Remove(parent);
            _db.SaveChanges();
            return RedirectToAction("Index", "ParentController1");
        }



        public ActionResult Details(int? id)
        {
            var obj = _db.Parents.Where(temp => temp.ParentId == id).FirstOrDefault();
            return View(obj);
        }

    }
}
