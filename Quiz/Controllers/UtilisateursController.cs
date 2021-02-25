
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuizApp.Controllers;
using QuizApp.Filters;
using QuizApp.Interceptors;
using QuizApp.Models;
using QuizApp.Repositories;
using QuizApp.Services;

namespace QuizAppS.Controllers
{
    [RoutePrefix("Users")]
    [Route("{action=index}")]
    [LoginFilter]
    [RolesFilter(UserRole.ADMIN)]
    public class UtilisateursController : Controller
    {
        private IUserService userService;

        private MyContext db = new MyContext();

        public UtilisateursController()
        {
            userService = new UserService(new UserRepository(db));
        }

        //[LoginFilter]
        //[RolesFilter(UserRole.ADMIN)]
        [HttpGet]
        [Route("{page?}/{maxByPage?}/{searchField?}")]
        public ActionResult Index(int page = 1, int maxByPage = MyConstants.MAX_BY_PAGE, string searchField = "")
        {
            List<Utilisateur> userLst = userService.FindAll(page, maxByPage, searchField);
            ViewBag.page = page;
            ViewBag.maxByPage = maxByPage;
            ViewBag.searchField = searchField;
            ViewBag.NextExist = userService.NextExist(page, maxByPage, searchField);
            return View("Index", userLst);
        }

        [HttpGet]
        [Route("Search")]
        public ActionResult Search([Bind(Include = "searchField")] string searchField)
        {
            return Index(searchField: searchField);
        }


        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "Id,Name,Email,Password,Role")] Utilisateur user)
        {
            if (ModelState.IsValid)
            {
                userService.Save(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }


        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur user = userService.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur user = userService.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Password,Role")] Utilisateur user)
        {
            if (ModelState.IsValid)
            {

                userService.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur user = userService.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            userService.Remove(id);
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
