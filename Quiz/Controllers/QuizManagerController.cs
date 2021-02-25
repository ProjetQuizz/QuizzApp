﻿using QuizApp.Interceptors;
using QuizApp.Models;
using QuizApp.Repositories;
using QuizApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class QuizManagerController : Controller
    {
        // GET: QuizManager  

        private MyContext db = new MyContext();
<<<<<<< HEAD
        private IQuizService quizService;

        private IQuizQuestionService questionService;

=======
        IQuizService quizService;

        IQuizQuestionService questionService;
        QuizTest quizTest;
        QuizQuestion qst;
        string choiceStr;
>>>>>>> 8921967022a046197d837e798133eeeab3b2ed14

        public QuizManagerController()
        {
            quizService = new QuizService(new QuizRepository(db));
            questionService = new QuizQuestionService(new QuizQuestionRepository(db));
        }


        // GET: Quiz
        public ActionResult Index()
        {
            ViewData["QuizList"] = QuizList;
            return View();
        }

        public IEnumerable<SelectListItem> QuizList
        {
            get
            {
                return new SelectList(quizService.FindAll(), "Id", "Subject");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Start(FormCollection form)
        {
            Session["score"] = 0;

            int selectedQuizId = Convert.ToInt32(form.Get("SelectedQuizId"));
            Session["quizId"] = selectedQuizId;
            Session["ordre"] = 1;

            QuizQuestion qst = questionService.FindQuestion(selectedQuizId, 1);
            return View("Progress", qst);
        }


       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Next(FormCollection form)
        {
            int score = Convert.ToInt32(Session["score"]);
            int selectedQuizId = Convert.ToInt32(Session["quizId"]);
            int ordre = Convert.ToInt32(Session["ordre"]);
            Quizz qcm = quizService.FindById(selectedQuizId);
            QuizQuestion qstEnCours = qcm.Questions[ordre - 1];

            if (!qstEnCours.IsMultiple)
            {

                int idRepSel = Convert.ToInt32(form.Get("selectedSimpleRep"));
                if (quizService.FindReponse(selectedQuizId, qstEnCours.Id, idRepSel).IsCorrect)
                {
                    score++;
                    Session["score"] = score;
                }
<<<<<<< HEAD
                else
                {
                    score--;
                    Session["score"] = score;
                }
            }
            else 
=======
            }
            else if (qstEnCours.IsMultiple)
>>>>>>> 8921967022a046197d837e798133eeeab3b2ed14
            {
                // 
                string[] reponses = form.GetValues("selectedRep[]");
                bool[] tabRep = new bool[reponses.Length];
                for (int i = 0; i < reponses.Length; i++)
                {
                    tabRep[i] = quizService.FindReponse(selectedQuizId, qstEnCours.Id,
                                                    Convert.ToInt32(reponses[i])).IsCorrect;
                }
<<<<<<< HEAD
                bool exist = tabRep.Contains(false);
                if (exist == true)
                {
                    score--;
                    Session["score"] = score;
                }

                else 
=======
                bool? exist = tabRep.ToList().Find(b => b == false);
                if (!exist.HasValue || (exist.HasValue && exist == false))
>>>>>>> 8921967022a046197d837e798133eeeab3b2ed14
                {
                    score++;
                    Session["score"] = score;
                }
<<<<<<< HEAD
            }



            

        //On vérifie s'il reste des questions à afficher
            if (ordre<qcm.Questions.Count)
=======



            }

            //On vérifie s'il reste des questions à afficher
            if (ordre < qcm.Questions.Count)
>>>>>>> 8921967022a046197d837e798133eeeab3b2ed14
            {
                ordre++;
                Session["ordre"] = ordre;
                QuizQuestion qst = questionService.FindQuestion(selectedQuizId, ordre);
                return View("Progress", qst);
            }
            else
            {
                //afficher le score
                return View("Result");
            }
        }


<<<<<<< HEAD
   }
=======
    }
>>>>>>> 8921967022a046197d837e798133eeeab3b2ed14
}
