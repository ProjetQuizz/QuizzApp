using QuizApp.Filters;
using QuizApp.Interceptors;
using QuizApp.Models;
using QuizApp.Repositories;
using QuizApp.Services;
using QuizApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class HomeController : Controller
    {
        private MyContext db = new MyContext();
        //IQuizService quizService;
        private int numQst = 1;
        private QuizQuestionService quizService;
        public ActionResult Index(string Category=null)
        {
            List<Quizz> quizs;
            List<QuizCategory> quizCategories = db.QuizCategories.ToList();
            if(Category == null)
            {
                quizs = db.Quizs.ToList();
            }
            else
            {
                quizs = db.Quizs.Where(q => q.Category == Category).ToList();
            }
            QuizListViewModel quizListView = new QuizListViewModel();
            quizListView.Quizs = quizs;
            quizListView.QuizCategories = quizCategories;
            return View(quizListView);
        }
        //[LoginFilter]
        //[RolesFilter(UserRole.USER)]
        public ActionResult Demarrer(int id)
        {
            Quizz quiz = db.Quizs.Find(id);
            Utilisateur candidat = new Utilisateur();
                //(Utilisateur)Session["user"];
            QuizTest quizTest = new QuizTest(DateTime.Now, quiz, candidat, 0);
            return View(quizTest);
        }

        //Méthode qui vérifie la réponse
        public void CheckResponse(QuizTest quizTest, QuizQuestion qst, string choiceStr)
        {
            if (!qst.IsMultiple) //1 réponse possible
            {
                int choice = Convert.ToInt32(choiceStr);
                if (choice < 1 || choice > qst.Reponses.Count)
                {
                    throw new Exception("Erreur: le choix doit être entre 1 et " + qst.Reponses.Count);
                }

                if (qst.Reponses[choice - 1].IsCorrect)
                {
                    quizTest.Score++;
                }

                quizTest.UserReponses.Add(qst, new List<QuizReponse>() { qst.Reponses[choice - 1] });
            }
            else //plusieurs réponses possibles 1,3
            {
                string[] choices = choiceStr.Split(',');
                List<QuizReponse> userResp = new List<QuizReponse>();
                foreach (string choice in choices)
                {
                    int choiceX = Convert.ToInt32(choice);
                    if (choiceX < 1 || choiceX > qst.Reponses.Count)
                    {
                        throw new Exception("Erreur: le choix doit être entre 1 et " + qst.Reponses.Count);
                    }

                    if (qst.Reponses[choiceX - 1].IsCorrect)
                    {
                        quizTest.Score++;
                    }
                    else
                    {
                        quizTest.Score--;
                    }

                    userResp.Add(qst.Reponses[choiceX - 1]);
                }
                quizTest.UserReponses.Add(qst, userResp);
            }

          

        }
    }
}