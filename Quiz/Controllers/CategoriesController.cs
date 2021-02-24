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
    public class CategoriesController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.QuizCategories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizCategory quizCategory = db.QuizCategories.Find(id);
            if (quizCategory == null)
            {
                return HttpNotFound();
            }
            return View(quizCategory);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Category")] QuizCategory quizCategory)
        {
            if (ModelState.IsValid)
            {
                db.QuizCategories.Add(quizCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quizCategory);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizCategory quizCategory = db.QuizCategories.Find(id);
            if (quizCategory == null)
            {
                return HttpNotFound();
            }
            return View(quizCategory);
        }

        // POST: Categories/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Category")] QuizCategory quizCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quizCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quizCategory);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizCategory quizCategory = db.QuizCategories.Find(id);
            if (quizCategory == null)
            {
                return HttpNotFound();
            }
            return View(quizCategory);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuizCategory quizCategory = db.QuizCategories.Find(id);
            db.QuizCategories.Remove(quizCategory);
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
