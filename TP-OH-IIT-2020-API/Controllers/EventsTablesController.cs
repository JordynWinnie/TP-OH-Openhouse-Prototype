using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace TP_OH_IIT_2020_API.Controllers
{
    public class EventsTablesController : Controller
    {
        private TPOHEntities db = new TPOHEntities();

        public EventsTablesController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        public ActionResult GetEvents(int? id)
        {
            if (id != null)
            {
                var events = from x in db.EventsTables
                             where x.eventID == id && x.EventTimings.Count > 0
                             select new
                             {
                                 x.eventID,
                                 x.eventName,
                                 x.eventDescription,
                                 x.creditsToEarn,
                                 x.CourseTable.courseName,
                                 x.CourseTable.courseShortName,
                                 x.CourseTable.courseCode,
                                 x.qrCodeString,
                                 x.EventTimings,
                                 x.invitationLink
                             };
                return Json(events.First(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var events = from x in db.EventsTables
                             where x.EventTimings.Count > 0
                             select new
                             {
                                 x.eventID,
                                 x.eventName,
                                 x.eventDescription,
                                 x.creditsToEarn,
                                 x.CourseTable.courseName,
                                 x.CourseTable.courseShortName,
                                 x.CourseTable.courseCode,
                                 x.qrCodeString,
                                 x.EventTimings,
                                 x.invitationLink
                             };
                return Json(events, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: EventsTables
        public ActionResult Index()
        {
            return View(db.EventsTables.ToList());
        }

        // GET: EventsTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsTable eventsTable = db.EventsTables.Find(id);
            if (eventsTable == null)
            {
                return HttpNotFound();
            }
            return View(eventsTable);
        }

        // GET: EventsTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventsTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "eventID,eventName,eventDescription,creditsToEarn,qrCodeString")] EventsTable eventsTable)
        {
            if (ModelState.IsValid)
            {
                db.EventsTables.Add(eventsTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventsTable);
        }

        // GET: EventsTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsTable eventsTable = db.EventsTables.Find(id);
            if (eventsTable == null)
            {
                return HttpNotFound();
            }
            return View(eventsTable);
        }

        // POST: EventsTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "eventID,eventName,eventDescription,creditsToEarn,qrCodeString")] EventsTable eventsTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventsTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventsTable);
        }

        // GET: EventsTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsTable eventsTable = db.EventsTables.Find(id);
            if (eventsTable == null)
            {
                return HttpNotFound();
            }
            return View(eventsTable);
        }

        // POST: EventsTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventsTable eventsTable = db.EventsTables.Find(id);
            db.EventsTables.Remove(eventsTable);
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