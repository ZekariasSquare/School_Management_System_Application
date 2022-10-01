using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using School_Management_System_Application.Data;
using School_Management_System_Application.Models;
namespace School_Management_System_Application.Controllers
{
    public class GradeController1 : Controller
    {
        private readonly ApplicationDbContext _db;
        public GradeController1(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string Search=" ")
        {
            List<Grade> grades;

            if (Search != "" && Search != null)
            {
                grades = _db.Grades
                    .Where(p => p.studentId.Contains(Search))
                    .ToList();
            }
            else
            {
                grades = _db.Grades.ToList();

            }
            return View(grades);
        }

        public IActionResult FindGrade(string Search = " ")
        {
            List<Grade> grades;

            if (Search != "" && Search != null)
            {
                grades = _db.Grades
                    .Where(p => p.studentId.Contains(Search))
                    .ToList();
            }
            else
            {
                grades = _db.Grades.ToList();

            }
            return View(grades);
        }
        //GET
        public ActionResult InsertGrade()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertGrade(Grade s)
        {
            if (ModelState.IsValid)
            {
                _db.Grades.Add(s);
                _db.SaveChanges();
                return RedirectToAction("Index", "GradeController1");
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
            var obj = _db.Grades.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Grade c)
        {
            if (ModelState.IsValid)
            {
                _db.Grades.Update(c);
                _db.SaveChanges();
                return RedirectToAction("Index", "GradeController1");
            }
            return View(c);
        }


        public ActionResult Delete(long? id)
        {
            var grade = _db.Grades.Where(temp => temp.GradeId == id).FirstOrDefault();
            _db.Grades.Remove(grade);
            _db.SaveChanges();
            return RedirectToAction("Index", "GradeController1");
        }



        public ActionResult Details(int? id)
        {
            var obj = _db.Grades.Where(temp => temp.GradeId == id).FirstOrDefault();
            return View(obj);
        }
    }
}
