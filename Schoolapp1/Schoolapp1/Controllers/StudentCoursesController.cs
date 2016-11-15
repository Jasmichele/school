using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Schoolapp1;
using System.Data;

namespace Schoolapp1.Controllers
{
    public class StudentCoursesController : Controller
    {
        private SchoolEntities1 db = new SchoolEntities1();
        // GET: StudentCourses
        public ActionResult Index()
        {
            var studentCourses = db.StudentCourses.Include(s => s.student).Include(s => s.Cours);
            return View(studentCourses.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCours stucou = db.StudentCourses.Find(id);
            if (stucou == null)
            {
                return HttpNotFound();
            }
            return View(stucou);
        }

        public ActionResult Create()
        {
            ViewBag.StudentsID = new SelectList(db.students, "StudeneID", "StudentName");
            ViewBag.CoursesID = new SelectList(db.Courses, "CourseId", "CourseName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentsID,CoursesID")] StudentCours stuc)
        {
            if (ModelState.IsValid)
            {
                db.StudentCourses.Add(stuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stuc);
        }

        public ActionResult Edit(int StudeneID, int CourseId)
        {

            StudentCours stucou = db.StudentCourses.Find(StudeneID, CourseId);
            if (stucou == null)
            {
                return HttpNotFound();
            }

            ViewBag.StudeneID = new SelectList(db.students, "StudeneID", "StudentName", stucou.StudentsID);
            ViewBag.CourseID = new SelectList(db.Courses, "CourseId", "CourseName", stucou.CoursesID);
            return View(stucou);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentsID,CoursesID")] StudentCours stc)
        {
            if (ModelState.IsValid)
            {

                db.Entry(stc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stc);
    }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCours stucou = db.StudentCourses.Find(id);
            if (stucou == null)
            {
                return HttpNotFound();
            }
            return View(stucou);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentCours stu = db.StudentCourses.Find(id);
            db.StudentCourses.Remove(stu);
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