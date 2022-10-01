using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using School_Management_System_Application.Data;
using School_Management_System_Application.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace School_Management_System_Application.Controllers
{
    public class StudentController1 : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentController1(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string Search="")
        {

            List<Student> students;
                
            if(Search !="" && Search != null)
            {
                students =_db.Students
                    .Where(p => p.Student_ID.Contains(Search))
                    .ToList();
            }
            else
            {
                students = _db.Students.ToList();
                
            }
            return View(students);
        }

    

        public ActionResult Registeration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registeration(Student s)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(s);
                _db.SaveChanges();
                return RedirectToAction("Index", "StudentController1");
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
        public ActionResult Login(Student s)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = _db)
                {
                    var obj = db.Students.Where(temp => temp.Student_ID.Equals(s.Student_ID)).FirstOrDefault();
                    if (obj == null)
                    {
                        ModelState.AddModelError("", "You are not registerd !!!. please contact the registeral office");
                    }
                    else
                    {
                        return RedirectToAction("Welcome", "StudentController1");
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
            var obj = _db.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student c)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Update(c);
                _db.SaveChanges();
                return RedirectToAction("Index", "StudentController1");
            }
            return View(c);
        }

        public ActionResult Delete(long id)
        {
            var student = _db.Students.Where(temp => temp.Id == id).FirstOrDefault();
            _db.Students.Remove(student);
            _db.SaveChanges();
            return RedirectToAction("Index", "StudentController1");
        }

     

        public ActionResult Details(long? id)
        {
            var obj = _db.Students.Where(temp => temp.Id == id).FirstOrDefault();
            return View(obj);
        }

        

    }
}
