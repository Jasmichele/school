using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using Schoolapp1;

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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours course = db.Courses.Find(id);
            if(course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CoursesID,CourseName,CourseDesc")] Cours course)
        {
            if(ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours course = db.Courses.Find(id);
            if(course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CoursesID,CourseName,CourseDesc")] Cours courses)
        {
            if(ModelState.IsValid)
            {
                db.Entry(courses).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courses);
        }
    }
}