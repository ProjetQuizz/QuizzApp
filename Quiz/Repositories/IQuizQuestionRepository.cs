using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Repositories
{
   public interface IQuizQuestionRepository
    {
        QuizQuestion FindQuestion(int quizId, int numOrder);
        List<QuizQuestion> FindAll(int start, int max, string searchField);
        int Count(string searchField);
        List<QuizQuestion> FindAll();
        List<Quizz> FindQuiz(int quizId);
        List<QuizReponse> FindReponses();
        QuizQuestion FindQuestionById(int questionId);
        int CountQuestions(int quizId);
        void Delete(int id);
        void Insert(QuizQuestion quizQuestion);
        void SaveChanges();
        void Update(QuizQuestion quizQuestion);
    }
}
