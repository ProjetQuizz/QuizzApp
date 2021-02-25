using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Services
{
   public interface IQuizQuestionService
    {
        List<QuizQuestion> FindAll();
        List<QuizQuestion> FindAll(int page, int maxByPage, string searchField);
        bool NextExist(int page, int maxByPage, string searchField);
        List<QuizReponse> FindReponses();
        QuizQuestion FindQuestion(int quizId, int numOrder);
        List<Quizz> FindQuiz(int quizId);
        QuizQuestion FindQuestionById(int questionId);
        int CountQuestions(int quizId);
        void Delete(int id);
        void Insert(QuizQuestion quizQuestion);
        void SaveChanges();
        void Update(QuizQuestion quizQuestion);
    }
}
