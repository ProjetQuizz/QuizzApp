﻿using QuizApp.Models;
using QuizApp.Repositories;
using QuizApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class QuizzzController : Controller
    {
        private MyContext db = new MyContext();
        IQuizService quizService;

        IQuizQuestionService questionService;
        QuizTest quizTest;
        QuizQuestion qst;
        string choiceStr;

        public QuizzzController()
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

            QuizQuestion qst = questionService.FindQuestionById(selectedQuizId);
            return View("Progress", qst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Next(FormCollection form)
        {
          int score = Convert.ToInt32(Session["score"]);
            int selectedQuizId = Convert.ToInt32(Session["quizId"]);
            int ordre = Convert.ToInt32(Session["ordre"]);
            //  Quizz qcm = quizService.FindById(selectedQuizId);
            Quizz qcm = quizService.FindById(selectedQuizId);
            QuizQuestion qstEnCours = qcm.Questions[ordre - 1];

            //int score = Convert.ToInt32(Session["score"]);
            //int selectedQuizId = Convert.ToInt32(Session["quizId"]);
            //int ordre = Convert.ToInt32(Session["ordre"]);
            //Quiz qcm = QuizDao.FindQuiz(selectedQuizId);
            //Question qstEnCours = qcm.ListeQsts[ordre - 1];
            if (!qstEnCours.IsMultiple)
            {

                int idRepSel = Convert.ToInt32(form.Get("selectedSimpleRep"));
                if (quizService.FindReponse(selectedQuizId, qstEnCours.Id, idRepSel).IsCorrect)
                {
                    score++;
                    Session["score"] = score;
                }
            }
            else if(qstEnCours.IsMultiple)
            {
               // 
                string[] reponses = form.GetValues("selectedRep[]");
                bool[] tabRep = new bool[reponses.Length];
                for (int i = 0; i < reponses.Length; i++)
                {
                    tabRep[i] = quizService.FindReponse(selectedQuizId, qstEnCours.Id,
                                                    Convert.ToInt32(reponses[i])).IsCorrect;
                }
                bool? exist = tabRep.ToList().Find(b => b == false);
                if (!exist.HasValue || (exist.HasValue && exist == false))
                {
                    score++;
                    Session["score"] = score;
                }



            }

            //On vérifie s'il reste des questions à afficher
            if (ordre < qcm.Questions.Count)
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


    }
}

            //    if (!qstEnCours.IsMultiple)
            //    {
            //        int choice = Convert.ToInt32(choiceStr);
            //        if (choice < 1 || choice > qst.Reponses.Count)
            //        {
            //            throw new Exception("Erreur: le choix doit être entre 1 et " + qst.Reponses.Count);
            //        }

//        if (qst.Reponses[choice - 1].IsCorrect)
//        {
//            quizTest.Score++;
//        }

//        quizTest.UserReponses.Add(qst, new List<QuizReponse>() { qst.Reponses[choice - 1] });
//    }
//    else //plusieurs réponses possibles 1,3
//    {
//        string[] choices = choiceStr.Split(',');
//        List<QuizReponse> userResp = new List<QuizReponse>();
//        foreach (string choice in choices)
//        {
//            int choiceX = Convert.ToInt32(choice);
//            if (choiceX < 1 || choiceX > qst.Reponses.Count)
//            {
//                throw new Exception("Erreur: le choix doit être entre 1 et " + qst.Reponses.Count);
//            }

//            if (qst.Reponses[choiceX - 1].IsCorrect)
//            {
//                quizTest.Score++;
//            }
//            else
//            {
//                quizTest.Score--;
//            }

//            userResp.Add(qst.Reponses[choiceX - 1]);
//        }
//        quizTest.UserReponses.Add(qst, userResp);
//    }



//    //On vérifie s'il reste des questions à afficher
//    if (ordre < qcm.Questions.Count)
//    {
//        ordre++;
//        Session["ordre"] = ordre;
//        QuizQuestion qst = questionService.FindQuestion(selectedQuizId, ordre);
//        return View("Progress", qst);
//    }
//    else
//    {
//        //afficher le score
//        return View("Result");
//    }
//}