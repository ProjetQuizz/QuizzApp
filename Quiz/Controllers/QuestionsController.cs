using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuizApp.Interceptors;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    [RoutePrefix("Questions")]
    [RolesFilter(UserRole.ADMIN)]
    public class QuestionsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Questions
        public ActionResult Index()
        {
            var quizQuestions = db.QuizQuestions.Include(q => q.Quiz);
            return View(quizQuestions.ToList());
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizQuestion quizQuestion = db.QuizQuestions.Find(id);
            if (quizQuestion == null)
            {
                return HttpNotFound();
            }
            return View(quizQuestion);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            ViewBag.QuizId = new SelectList(db.Quizs, "Id", "Subject");
            return View();
        }

        // POST: Questions/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,QstText,IsMultiple,NumOrdrer,QuizId")] QuizQuestion quizQuestion)
        {
            if (ModelState.IsValid)
            {
                db.QuizQuestions.Add(quizQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuizId = new SelectList(db.Quizs, "Id", "Subject", quizQuestion.QuizId);
            return View(quizQuestion);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizQuestion quizQuestion = db.QuizQuestions.Find(id);
            if (quizQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuizId = new SelectList(db.Quizs, "Id", "Subject", quizQuestion.QuizId);
            return View(quizQuestion);
        }

        // POST: Questions/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,QstText,IsMultiple,NumOrdrer,QuizId")] QuizQuestion quizQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quizQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuizId = new SelectList(db.Quizs, "Id", "Subject", quizQuestion.QuizId);
            return View(quizQuestion);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizQuestion quizQuestion = db.QuizQuestions.Find(id);
            if (quizQuestion == null)
            {
                return HttpNotFound();
            }
            return View(quizQuestion);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuizQuestion quizQuestion = db.QuizQuestions.Find(id);
            db.QuizQuestions.Remove(quizQuestion);
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
