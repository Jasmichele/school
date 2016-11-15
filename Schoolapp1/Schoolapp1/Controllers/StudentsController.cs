using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Schoolapp1;
using Schoolapp1.Models;

namespace Schoolapp1.Controllers
{
    public class StudentsController : Controller
    {
        private SchoolEntities1 db = new SchoolEntities1();
        // GET: Students
        public ActionResult Index()
        {
            return View(db.students.ToList());
        }

        public ActionResult Details(int? id)
        {
            var catalog = from sc in db.StudentCourses
                          join c in db.Courses
                          on sc.CoursesID equals c.CourseID
                          where sc.StudentsID == id
                          select c;

            var st = (from sc in db.students
                      where sc.StudeneID == id
                      select sc).FirstOrDefault();

            cat chris = new cat();
            chris.Courses = catalog.ToList();
            chris.Student = st;


            return View(chris);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudeneID,StudentName")] student students)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(students);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student students = db.students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudeneID,StudentName")] student students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student students = db.students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student students = db.students.Find(id);
            db.students.Remove(students);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}