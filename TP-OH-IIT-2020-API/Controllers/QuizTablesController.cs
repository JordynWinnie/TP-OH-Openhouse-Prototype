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
    public class QuizTablesController : Controller
    {
        private TPOHEntities db = new TPOHEntities();

        public QuizTablesController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        public ActionResult GetQuizList()
        {
            var quizes = from x in db.QuizTables
                         select new
                         {
                             x.quizID,
                             x.quizName,
                             x.quizDescription,
                             quizQuestionCount = x.QuestionsTables.Count,
                             x.quizCredits
                         };
            return Json(quizes, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetQuizQuestions(int quizID)
        {
            var quiz = from x in db.QuestionsTables
                       where x.quizIDFK == quizID
                       select new
                       {
                           x.questionID,
                           x.questionString,
                           x.questionHint,
                       };

            return Json(quiz, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetQuizAnswers(int quizID)
        {
            var answers = from x in db.AnswersTables
                          where x.QuestionsTable.quizIDFK == quizID
                          select new
                          {
                              x.questionID,
                              x.answerString,
                              x.isCorrectAnswer
                          };

            return Json(answers, JsonRequestBehavior.AllowGet);
        }

        // GET: QuizTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizTable quizTable = db.QuizTables.Find(id);
            if (quizTable == null)
            {
                return HttpNotFound();
            }
            return View(quizTable);
        }

        // GET: QuizTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuizTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "quizID,quizName,quizDescription")] QuizTable quizTable)
        {
            if (ModelState.IsValid)
            {
                db.QuizTables.Add(quizTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quizTable);
        }

        // GET: QuizTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizTable quizTable = db.QuizTables.Find(id);
            if (quizTable == null)
            {
                return HttpNotFound();
            }
            return View(quizTable);
        }

        // POST: QuizTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "quizID,quizName,quizDescription")] QuizTable quizTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quizTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quizTable);
        }

        // GET: QuizTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizTable quizTable = db.QuizTables.Find(id);
            if (quizTable == null)
            {
                return HttpNotFound();
            }
            return View(quizTable);
        }

        // POST: QuizTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuizTable quizTable = db.QuizTables.Find(id);
            db.QuizTables.Remove(quizTable);
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