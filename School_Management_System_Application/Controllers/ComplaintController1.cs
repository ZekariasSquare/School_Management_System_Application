using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using School_Management_System_Application.Data;
using School_Management_System_Application.Models;


namespace School_Management_System_Application.Controllers
{
    public class ComplaintController1 : Controller
    {
        private readonly ApplicationDbContext _db;
        public ComplaintController1(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var Complaint = _db.Complaints.ToList();
            return View(Complaint);
        }

        public ActionResult ReportComplaint()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReportComplaint(Complaint s)
        {
            if (ModelState.IsValid)
            {
                _db.Complaints.Add(s);
                _db.SaveChanges();
                return RedirectToAction("Welcome", "StudentController1");
            }
            else
            {
                ModelState.AddModelError("", "Some Error Occured");
            }
            return View(s);
        }


    }
}
