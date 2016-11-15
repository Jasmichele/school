using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using Schoolapp1;
using Schoolapp1.Models;

namespace Schoolapp1.Controllers
{
    public class CoursesController : Controller
    {
        private SchoolEntities1 db = new SchoolEntities1();
        // GET: Courses
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        public ActionResult Details(int? id)
        {
            var catalog = from sc in db.StudentCourses
                          join s in db.students
                          on sc.StudentsID equals s.StudeneID
                          where sc.CoursesID == id
                          select s;

            var cr = (from c in db.Courses
                      where c.CourseID == id
                      select c).FirstOrDefault();

            Co ting = new Co();
            ting.MyStudent = catalog.ToList();
            ting.MyCourse = cr;

            return View(ting);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CoursesID,CourseName,CourseDesc")] Cours course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CoursesID,CourseName,CourseDesc")] Cours courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courses);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours courses = db.Courses.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cours courses = db.Courses.Find(id);
            db.Courses.Remove(courses);
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