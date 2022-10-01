using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using School_Management_System_Application.Data;
using School_Management_System_Application.Models;

namespace School_Management_System_Application.Controllers
{
    public class TeacherCourseController1 : Controller
    {
        private readonly ApplicationDbContext _db;
        public TeacherCourseController1(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var teachercourse = _db.TeacherCourses.ToList();
            return View(teachercourse);
        }

        public ActionResult AddTeacherCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTeacherCourse(TeacherCourse s)
        {
            if (ModelState.IsValid)
            {
                _db.TeacherCourses.Add(s);
                _db.SaveChanges();
                return RedirectToAction("Index", "TeacherCourseController1");
            }
            else
            {
                ModelState.AddModelError("", "Some Error Occured");
            }
            return View(s);
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _db.TeacherCourses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeacherCourse c)
        {
            if (ModelState.IsValid)
            {
                _db.TeacherCourses.Update(c);
                _db.SaveChanges();
                return RedirectToAction("Index", "TeacherCourseController1");
            }
            return View(c);
        }


        public ActionResult Delete(long? id)
        {
            var teachercourse = _db.TeacherCourses.Where(temp => temp.TcId == id).FirstOrDefault();
            _db.TeacherCourses.Remove(teachercourse);
            _db.SaveChanges();
            return RedirectToAction("Index", "TeacherCourseController1");
        }



        public ActionResult Details(long? id)
        {
            var obj = _db.TeacherCourses.Where(temp => temp.TcId == id).FirstOrDefault();
            return View(obj);
        }
    }
}
