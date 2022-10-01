using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using School_Management_System_Application.Data;
using School_Management_System_Application.Models;


namespace School_Management_System_Application.Controllers
{
    public class CourseController1 : Controller
    {
        private readonly ApplicationDbContext _db;
        public CourseController1(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var course = _db.Courses.ToList();
            return View(course);
        }

        //GET-POST
        public ActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCourse(Course c)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Add(c);
                _db.SaveChanges();
                return RedirectToAction("Index", "CourseController1");
            }
            else
            {
                ModelState.AddModelError("", "Some Error Occured");
            }
            return View(c);
        }




        //GET-Edit
        public IActionResult Edit(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = _db.Courses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course c)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Update(c);
                _db.SaveChanges();
                return RedirectToAction("Index", "CourseController1");
            }
            return View(c);
        }



        //GET-Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Course c)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Remove(c);
                _db.SaveChanges();
                return RedirectToAction("Index", "CourseController1");
            }
            return View(c);
        }

        public ActionResult Details(long? id)
        {
            var obj = _db.Courses.Where(temp => temp.CourseId == id).FirstOrDefault();
            return View(obj);
        }

    }

    

}
