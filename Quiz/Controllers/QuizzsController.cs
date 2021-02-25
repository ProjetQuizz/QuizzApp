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
    public class QuizzsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Quizzs
        public ActionResult Index()
        {
            return View(db.Quizs.ToList());
        }

        // GET: Quizzs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quizz quizz = db.Quizs.Find(id);
            if (quizz == null)
            {
                return HttpNotFound();
            }
            return View(quizz);
        }

        // GET: Quizzs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quizzs/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Subject,Description,Category")] Quizz quizz)
        {
            if (ModelState.IsValid)
            {
                db.Quizs.Add(quizz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quizz);
        }

        // GET: Quizzs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quizz quizz = db.Quizs.Find(id);
            if (quizz == null)
            {
                return HttpNotFound();
            }
            return View(quizz);
        }

        // POST: Quizzs/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Subject,Description,Category")] Quizz quizz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quizz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quizz);
        }

        // GET: Quizzs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quizz quizz = db.Quizs.Find(id);
            if (quizz == null)
            {
                return HttpNotFound();
            }
            return View(quizz);
        }

        // POST: Quizzs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quizz quizz = db.Quizs.Find(id);
            db.Quizs.Remove(quizz);
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
