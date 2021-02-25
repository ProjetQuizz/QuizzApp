using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace QuizApp.Models
{
    public class QuizTest
    {
        //public int Id { get; set; }
        public DateTime Date { get; set; }
        public Quizz Quizz { get; set; }
        public Utilisateur Candidat { get; set; }
        public int Score { get; set; }

        public Dictionary<QuizQuestion, List<QuizReponse>> UserReponses { get; set; }

        public QuizTest(DateTime date, Quizz quizz, Utilisateur candidat, int score)
        {
            Date = date;
            Quizz = quizz;
            Candidat = candidat;
            Score = score;
            UserReponses = new Dictionary<QuizQuestion, List<QuizReponse>>();
        }
        public QuizTest()
        {

        }

        //Méthode qui vérifie la réponse
        public void CheckResponse(QuizQuestion qst, string choiceStr)
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
                    Score++;
                }

                UserReponses.Add(qst, new List<QuizReponse>() { qst.Reponses[choice - 1] });
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
                        Score++;
                    }
                    else
                    {
                        Score--;
                    }

                    userResp.Add(qst.Reponses[choiceX - 1]);
                }
                UserReponses.Add(qst, userResp);
            }
        }

        //Méthode qui transmet le résultat par mail au candidat
        public void SendReport()
        {
            string emailBody = "Bonjour, \n Votre score pour le Quiz " + Quizz.Subject + " est de " + Score;

            //Ajouter les réponses du candidat
            MailMessage m = new MailMessage("noreply@dawan.fr", Candidat.Email, "Quizz Subject: " + Quizz.Subject, emailBody);

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Credentials = CredentialCache.DefaultNetworkCredentials; //ajouter les identifiants gmail
            client.Send(m);
        }
    }
}