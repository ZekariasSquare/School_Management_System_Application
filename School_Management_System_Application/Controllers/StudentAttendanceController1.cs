using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using School_Management_System_Application.Data;
using School_Management_System_Application.Models;


namespace School_Management_System_Application.Controllers
{
    public class StudentAttendanceController1 : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentAttendanceController1(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var LISTAttendance = _db.StudentAttendances.ToList();
            return View(LISTAttendance);
        }

        public IActionResult AttendanceView()
        {
            var LISTAttendance = _db.StudentAttendances.ToList();
            return View(LISTAttendance);
        }

        public ActionResult AddAttendance()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAttendance(StudentAttendance s)
        {
            if (ModelState.IsValid)
            {
                _db.StudentAttendances.Add(s);
                _db.SaveChanges();
                return RedirectToAction("Index", "StudentAttendanceController1");
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
            var obj = _db.StudentAttendances.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentAttendance c)
        {
            if (ModelState.IsValid)
            {
                _db.StudentAttendances.Update(c);
                _db.SaveChanges();
                return RedirectToAction("Index", "StudentAttendanceController1");
            }
            return View(c);
        }


        public ActionResult Delete(int? id)
        {
            var student = _db.StudentAttendances.Where(temp => temp.AttendanceId == id).FirstOrDefault();
            _db.StudentAttendances.Remove(student);
            _db.SaveChanges();
            return RedirectToAction("Index", "StudentAttendanceController1");
        }



        public ActionResult Details(int? id)
        {
            var obj = _db.StudentAttendances.Where(temp => temp.AttendanceId == id).FirstOrDefault();
            return View(obj);
        }
    }
}
