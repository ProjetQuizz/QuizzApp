using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Services
{
   public interface IQuizReponseService
    {
        List<QuizReponse> FindReponse(int questionId);
        List<QuizQuestion> FindQuestion(int questionId);
        QuizReponse FindReponseById(int reponseId);
        void Delete(int id);
        void Insert(QuizReponse quizReponse);
        void SaveChanges();
        void Update(QuizReponse quizReponse);
    }
}
