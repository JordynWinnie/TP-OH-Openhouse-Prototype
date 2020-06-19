using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TP_OH_IIT_2020_API;

namespace TP_OH_IIT_2020_API.Controllers
{
    public class CourseTablesController : Controller
    {
        private TPOHEntities db = new TPOHEntities();

        public CourseTablesController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        // GET: CourseTables
        public ActionResult Index()
        {
            return View(db.CourseTables.ToList());
        }

        public ActionResult GetCourses()
        {
            return Json(db.CourseTables, JsonRequestBehavior.AllowGet);
        }

        // GET: CourseTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTable courseTable = db.CourseTables.Find(id);
            if (courseTable == null)
            {
                return HttpNotFound();
            }
            return View(courseTable);
        }

        // GET: CourseTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "courseID,courseName,courseShortName,courseCode")] CourseTable courseTable)
        {
            if (ModelState.IsValid)
            {
                db.CourseTables.Add(courseTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseTable);
        }

        // GET: CourseTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTable courseTable = db.CourseTables.Find(id);
            if (courseTable == null)
            {
                return HttpNotFound();
            }
            return View(courseTable);
        }

        // POST: CourseTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "courseID,courseName,courseShortName,courseCode")] CourseTable courseTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseTable);
        }

        // GET: CourseTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTable courseTable = db.CourseTables.Find(id);
            if (courseTable == null)
            {
                return HttpNotFound();
            }
            return View(courseTable);
        }

        // POST: CourseTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseTable courseTable = db.CourseTables.Find(id);
            db.CourseTables.Remove(courseTable);
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