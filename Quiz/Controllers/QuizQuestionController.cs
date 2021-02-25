using PagedList;
using QuizApp.Interceptors;
using QuizApp.Models;
using QuizApp.Repositories;
using QuizApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    [RoutePrefix("QuizQuestion")]
    [Route("{action=index}")]
    [LoginFilter]
    [RolesFilter(UserRole.ADMIN)]
    public class QuizQuestionController : Controller
    {
        // GET: QuizQuestion

        IQuizQuestionService service;
        IQuizService quiz;
        private MyContext db = new MyContext();

        public QuizQuestionController()
        {
            service = new QuizQuestionService(new QuizQuestionRepository(new MyContext()));
            quiz = new QuizService(new QuizRepository(new MyContext()));
        }
        public QuizQuestionController(IQuizQuestionService service, IQuizService quiz)
        {
            this.service = service;
            this.quiz = quiz;
        }



        [HttpGet]
        [Route("{page?}/{maxByPage?}/{searchField?}")]
        public ActionResult Index(int page = 1, int maxByPage = MyConstants.MAX_BY_PAGE, string searchField = "")
        {
            List<QuizQuestion> usersLst = service.FindAll(page, maxByPage, searchField);
            ViewBag.Page = page;
            ViewBag.maxByPage = maxByPage;
            ViewBag.searchField = searchField;
            ViewBag.NextExist = service.NextExist(page, maxByPage, searchField);
            return View("Index", usersLst);
        }

        [HttpGet]
        [Route("Search")]
        public ActionResult Search([Bind(Include = "searchField")] string searchField)
        {
            return Index(searchField: searchField);
        }


        //// GET: Questions
        //public ActionResult Index()
        //{

        //    return View(service.FindAll().ToList());
        //}


        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.QuizId = new SelectList(db.Quizs, "Id", "Subject");
            return View();
        }




        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,QstText,IsMultiple,NumOrdrer,QuizId")] QuizQuestion quizQuestion)
        {
            if (ModelState.IsValid)
            {
                service.Insert(quizQuestion);
                service.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuizId = new SelectList(db.Quizs, "Id", "Subject", quizQuestion.QuizId);
            return View(quizQuestion);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {

            QuizQuestion quizQuestion = service.FindQuestionById(id);
            if (quizQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuizId = new SelectList(db.Quizs, "Id", "Subject", quizQuestion.QuizId);
            return View(quizQuestion);
        }


        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,QstText,IsMultiple,NumOrdrer,QuizId")] QuizQuestion quizQuestion)
        {
            if (ModelState.IsValid)
            {
                service.Update(quizQuestion);
                service.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuizId = new SelectList(db.Quizs, "Id", "Subject", quizQuestion.QuizId);
            return View(quizQuestion);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {

            QuizQuestion quizQuestion = service.FindQuestionById(id);
            if (quizQuestion == null)
            {
                return HttpNotFound();
            }
            return View(quizQuestion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuizQuestion quizQuestion = service.FindQuestionById(id);
            service.Delete(id);
            service.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {

            QuizQuestion quizQuestion = service.FindQuestionById(id);
            if (quizQuestion == null)
            {
                return HttpNotFound();
            }
            return View(quizQuestion);
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
