using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using School_Management_System_Application.Data;
using School_Management_System_Application.Models;

namespace School_Management_System_Application.Controllers
{
    public class TeacherController1 : Controller
    {
        private readonly ApplicationDbContext _db;
        public TeacherController1(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var ListTeacher = _db.Teachers.ToList();
            return View(ListTeacher);
        }


        public ActionResult AddTeacher()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTeacher(Teacher s)
        {
            if (ModelState.IsValid)
            {
                _db.Teachers.Add(s);
                _db.SaveChanges();
                return RedirectToAction("Index", "TeacherController1");
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
        public ActionResult Login(Teacher t)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = _db)
                {
                    var obj = db.Teachers.Where(temp => temp.username.Equals(t.username) && temp.password.Equals(t.password)).FirstOrDefault();
                    if (obj == null)
                    {
                        ModelState.AddModelError("", "You are not registerd !!!. please contact the registeral office");
                    }
                    else
                    {
                        return RedirectToAction("Welcome", "TeacherController1");
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
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _db.Teachers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teacher c)
        {
            if (ModelState.IsValid)
            {
                _db.Teachers.Update(c);
                _db.SaveChanges();
                return RedirectToAction("Index", "TeacherController1");
            }
            return View(c);
        }



        public ActionResult Delete(long id)
        {
            var teacher = _db.Teachers.Where(temp => temp.Id == id).FirstOrDefault();
            _db.Teachers.Remove(teacher);
            _db.SaveChanges();
            return RedirectToAction("Index", "TeacherController1");
        }



        public ActionResult Details(long? id)
        {
            var obj = _db.Teachers.Where(temp => temp.Id == id).FirstOrDefault();
            return View(obj);
        }
    }
}
