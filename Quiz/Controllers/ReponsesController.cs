using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public class ReponsesController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Reponses
        public ActionResult Index()
        {
            var quizReponses = db.QuizReponses.Include(q => q.QuizQuestion);
            return View(quizReponses.ToList());
        }

        // GET: Reponses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizReponse quizReponse = db.QuizReponses.Find(id);
            if (quizReponse == null)
            {
                return HttpNotFound();
            }
            return View(quizReponse);
        }

        // GET: Reponses/Create
        public ActionResult Create()
        {
            ViewBag.QuizQuestionId = new SelectList(db.QuizQuestions, "Id", "QstText");
            return View();
        }

        // POST: Reponses/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RespText,IsCorrect,QuizQuestionId")] QuizReponse quizReponse)
        {
            if (ModelState.IsValid)
            {
                db.QuizReponses.Add(quizReponse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuizQuestionId = new SelectList(db.QuizQuestions, "Id", "QstText", quizReponse.QuizQuestionId);
            return View(quizReponse);
        }

        // GET: Reponses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizReponse quizReponse = db.QuizReponses.Find(id);
            if (quizReponse == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuizQuestionId = new SelectList(db.QuizQuestions, "Id", "QstText", quizReponse.QuizQuestionId);
            return View(quizReponse);
        }

        // POST: Reponses/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RespText,IsCorrect,QuizQuestionId")] QuizReponse quizReponse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quizReponse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuizQuestionId = new SelectList(db.QuizQuestions, "Id", "QstText", quizReponse.QuizQuestionId);
            return View(quizReponse);
        }

        // GET: Reponses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizReponse quizReponse = db.QuizReponses.Find(id);
            if (quizReponse == null)
            {
                return HttpNotFound();
            }
            return View(quizReponse);
        }

        // POST: Reponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuizReponse quizReponse = db.QuizReponses.Find(id);
            db.QuizReponses.Remove(quizReponse);
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
