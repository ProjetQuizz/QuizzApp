using QuizApp.Filters;
using QuizApp.Interceptors;
using QuizApp.Models;
using QuizApp.Repositories;
using QuizApp.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.Controllers
{

    [RoutePrefix("QuizCategory")]
    [Route("{action=index}")]
    [LoginFilter]
    [RolesFilter(UserRole.ADMIN)]
    public class QuizCategoryController : Controller
    {
        private MyContext db = new MyContext();
        IQuizCategoryService categoryService;
        
        public QuizCategoryController()
        {
            categoryService = new QuizCategoryService(new QuizCategoryRepository(db));
        }

  
        [HttpGet]
        [Route("{page?}/{maxByPage?}/{searchField?}")]
        public ActionResult Index(int page = 1, int maxByPage = MyConstants.MAX_BY_PAGE, string searchField = "")
        {
            List<QuizCategory> usersLst = categoryService.FindAll(page, maxByPage, searchField);
            ViewBag.Page = page;
            ViewBag.maxByPage = maxByPage;
            ViewBag.searchField = searchField;
            ViewBag.NextExist = categoryService.NextExist(page, maxByPage, searchField);
            return View("Index", usersLst);
        }

        [HttpGet]
        [Route("Search")]
        public ActionResult Search([Bind(Include = "searchField")] string searchField)
        {
            return Index(searchField: searchField);
        }
        //public ActionResult Index()
        //{
        //    List<QuizCategory> Categories = categoryService.FindAll().ToList();
        //    return View(Categories);
        //}

        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            QuizCategory c = new QuizCategory();
            return View(c);

        }

        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Category")] QuizCategory quizcategory)
        {


            if (ModelState.IsValid)
            {

                categoryService.Insert(quizcategory);
                categoryService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quizcategory);


        }
        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
          QuizCategory quizCategory = categoryService.FindCategoryById(id);
            if (quizCategory == null)
            {
                return HttpNotFound();
            }
            return View(quizCategory);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
            {
        
                QuizCategory quizCategory = categoryService.FindCategoryById(id);
                if (quizCategory == null)
                {
                    return HttpNotFound();
                }
              
                return View(quizCategory);
            }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Category")] QuizCategory quizCategory)
        {
            if (ModelState.IsValid)
            {
                categoryService.Update(quizCategory);
                categoryService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quizCategory);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                QuizCategory c = categoryService.FindCategoryById(id);
                if (c == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(c);
                }
            }
            catch (Exception)
            {

                return HttpNotFound();
            }

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id}")]
        public ActionResult ConfirDelete(int id)
        {
            try
            {
                QuizCategory cToDelete = categoryService.FindCategoryById(id);
                if (cToDelete == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    categoryService.Delete(id);
                    categoryService.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                return HttpNotFound();
            }

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