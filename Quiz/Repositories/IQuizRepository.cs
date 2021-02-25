using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Repositories
{
   public interface IQuizRepository
    {
        IQueryable<Quizz> Collection();
        QuizReponse FindReponse(int quizId, int questionId, int repId);

        //int CountQuestions(int quizId);
        List<Quizz> FindAll();
        Quizz FindById(int quizId);
        List<QuizQuestion> FindQuizQuestion();
        void Delete(int id);
        void Insert(Quizz quiz);
        void SaveChanges();
        void Update(Quizz quiz);
    }
}
