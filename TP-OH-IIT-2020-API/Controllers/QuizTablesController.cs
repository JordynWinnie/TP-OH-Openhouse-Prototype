using MoreLinq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
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

        public ActionResult ClaimCredits(int userID, int quizID)
        {
            var quiz = (from x in db.QuizTables
                        where x.quizID == quizID
                        select x).First();

            var user = (from x in db.Users
                        where x.userid == userID
                        select x).First();

            var checkIfUsed = (from x in db.QuizEarnedCredits
                               where x.userIDFK == userID && x.quizIDFK == quizID
                               select x).Any();

            if (checkIfUsed)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            try
            {
                var creditClaim = new QuizEarnedCredit
                {
                    quizIDFK = quizID,
                    userIDFK = userID
                };
                db.QuizEarnedCredits.Add(creditClaim);
                user.credits += (int)quiz.quizCredits;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(ex);
                throw;
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult PostResult(int quizID, int userID, int score)
        {
            var quizAttempt = new QuizAttempt

            {
                quizIDFK = quizID,
                score = score,
                useridFK = userID
            };

            db.QuizAttempts.Add(quizAttempt);

            try
            {
                db.SaveChanges();
                return Json(quizAttempt);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public ActionResult ReturnLeaderBoardForQuiz(int quizID)
        {
            var quizLeaderBoard = (from x in db.QuizAttempts
                                   where x.quizIDFK == quizID
                                   orderby x.score descending
                                   select new
                                   {
                                       x.User.username,
                                       x.score
                                   }).DistinctBy(x => x.username);

            return Json(quizLeaderBoard.Take(5), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetQuizList(int? quizID)
        {
            if (quizID != null)
            {
                var quizes = from x in db.QuizTables
                             where x.quizID == quizID
                             select new
                             {
                                 x.quizID,
                                 x.quizName,
                                 x.quizDescription,
                                 quizQuestionCount = x.QuestionsTables.Count,
                                 x.quizCredits
                             };
                return Json(quizes.First(), JsonRequestBehavior.AllowGet);
            }
            else
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
                           x.questionTrivia
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