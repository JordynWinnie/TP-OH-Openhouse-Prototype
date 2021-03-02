using Microsoft.Ajax.Utilities;
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
    public class AwardRedemptionsController : Controller
    {
        private TPOHEntities db = new TPOHEntities();

        public AwardRedemptionsController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        public ActionResult GetReward(int userID)
        {
            var rewards = (from x in db.AwardRedemptions
                           where x.useridFK == userID
                           select new
                           {
                               x.awardIdFK,
                               x.isAwardUsed,
                               x.AwardsTable.awardName,
                               x.UUID
                           });
            return Json(rewards, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ConfirmRewardRedemption(Guid guid)
        {
            var redemption = (from x in db.AwardRedemptions
                              where x.UUID == guid && x.isAwardUsed == true
                              select x);
            if (redemption.Any())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult RedeemReward(Guid guid)
        {
            var redemption = (from x in db.AwardRedemptions
                              where x.UUID == guid
                              select x);
            if (!redemption.Any())
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            if (redemption.First().isAwardUsed)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            else
            {
                redemption.First().isAwardUsed = true;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return Json(ex, JsonRequestBehavior.AllowGet);
                    throw;
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        // GET: AwardRedemptions
        public ActionResult Index()
        {
            var awardRedemptions = db.AwardRedemptions.Include(a => a.AwardsTable).Include(a => a.User);
            return View(awardRedemptions.ToList());
        }

        // GET: AwardRedemptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AwardRedemption awardRedemption = db.AwardRedemptions.Find(id);
            if (awardRedemption == null)
            {
                return HttpNotFound();
            }
            return View(awardRedemption);
        }

        // GET: AwardRedemptions/Create
        public ActionResult Create()
        {
            ViewBag.awardIdFK = new SelectList(db.AwardsTables, "awardID", "awardName");
            ViewBag.useridFK = new SelectList(db.Users, "userid", "username");
            return View();
        }

        // POST: AwardRedemptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "redemptionID,useridFK,awardIdFK,isAwardUsed,UUID")] AwardRedemption awardRedemption)
        {
            if (ModelState.IsValid)
            {
                db.AwardRedemptions.Add(awardRedemption);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.awardIdFK = new SelectList(db.AwardsTables, "awardID", "awardName", awardRedemption.awardIdFK);
            ViewBag.useridFK = new SelectList(db.Users, "userid", "username", awardRedemption.useridFK);
            return View(awardRedemption);
        }

        // GET: AwardRedemptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AwardRedemption awardRedemption = db.AwardRedemptions.Find(id);
            if (awardRedemption == null)
            {
                return HttpNotFound();
            }
            ViewBag.awardIdFK = new SelectList(db.AwardsTables, "awardID", "awardName", awardRedemption.awardIdFK);
            ViewBag.useridFK = new SelectList(db.Users, "userid", "username", awardRedemption.useridFK);
            return View(awardRedemption);
        }

        // POST: AwardRedemptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "redemptionID,useridFK,awardIdFK,isAwardUsed,UUID")] AwardRedemption awardRedemption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(awardRedemption).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.awardIdFK = new SelectList(db.AwardsTables, "awardID", "awardName", awardRedemption.awardIdFK);
            ViewBag.useridFK = new SelectList(db.Users, "userid", "username", awardRedemption.useridFK);
            return View(awardRedemption);
        }

        // GET: AwardRedemptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AwardRedemption awardRedemption = db.AwardRedemptions.Find(id);
            if (awardRedemption == null)
            {
                return HttpNotFound();
            }
            return View(awardRedemption);
        }

        // POST: AwardRedemptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AwardRedemption awardRedemption = db.AwardRedemptions.Find(id);
            db.AwardRedemptions.Remove(awardRedemption);
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