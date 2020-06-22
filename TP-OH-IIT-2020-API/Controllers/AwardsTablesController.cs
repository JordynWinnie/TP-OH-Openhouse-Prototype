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
    public class AwardsTablesController : Controller
    {
        private TPOHEntities db = new TPOHEntities();

        public AwardsTablesController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        public ActionResult RedeemAward(int awardID, int userID)
        {
            var user = (from x in db.Users
                        where x.userid == userID
                        select x).First();

            var award = (from x in db.AwardsTables
                         where x.awardID == awardID
                         select x).First();

            var redemptionCount = (from x in db.AwardRedemptions
                                   where x.awardIdFK == awardID
                                   select x).Count();

            var checkForRedemption = (from x in db.AwardRedemptions
                                      where x.awardIdFK == awardID && x.useridFK == userID
                                      select x).Any();

            if ((award.awardLimit - redemptionCount) <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            if (checkForRedemption)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            if (user.credits < award.creditsRequired)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable);
            }

            var insertAwardRedemption = new AwardRedemption
            {
                awardIdFK = awardID,
                useridFK = userID,
                isAwardUsed = false
            };

            db.AwardRedemptions.Add(insertAwardRedemption);
            user.credits -= award.creditsRequired;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
                throw;
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult GetAward(int? awardID)
        {
            if (awardID != null)
            {
                var awards = from x in db.AwardsTables
                             where x.awardID == awardID
                             select new
                             {
                                 x.awardName,
                                 x.awardDescription,
                                 Limit = x.awardLimit - x.AwardRedemptions.Where(y => y.awardIdFK == x.awardID).Count(),
                                 x.awardID,
                                 x.creditsRequired
                             };

                return Json(awards.First(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var awards = from x in db.AwardsTables
                             select new
                             {
                                 x.awardName,
                                 x.awardDescription,
                                 Limit = x.awardLimit - x.AwardRedemptions.Where(y => y.awardIdFK == x.awardID).Count(),
                                 x.awardID,
                                 x.creditsRequired
                             };

                return Json(awards, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: AwardsTables
        public ActionResult Index()
        {
            return View(db.AwardsTables.ToList());
        }

        // GET: AwardsTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AwardsTable awardsTable = db.AwardsTables.Find(id);
            if (awardsTable == null)
            {
                return HttpNotFound();
            }
            return View(awardsTable);
        }

        // GET: AwardsTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AwardsTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "awardID,awardName,awardDescription,awardLimit,creditsRequired")] AwardsTable awardsTable)
        {
            if (ModelState.IsValid)
            {
                db.AwardsTables.Add(awardsTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(awardsTable);
        }

        // GET: AwardsTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AwardsTable awardsTable = db.AwardsTables.Find(id);
            if (awardsTable == null)
            {
                return HttpNotFound();
            }
            return View(awardsTable);
        }

        // POST: AwardsTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "awardID,awardName,awardDescription,awardLimit,creditsRequired")] AwardsTable awardsTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(awardsTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(awardsTable);
        }

        // GET: AwardsTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AwardsTable awardsTable = db.AwardsTables.Find(id);
            if (awardsTable == null)
            {
                return HttpNotFound();
            }
            return View(awardsTable);
        }

        // POST: AwardsTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AwardsTable awardsTable = db.AwardsTables.Find(id);
            db.AwardsTables.Remove(awardsTable);
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