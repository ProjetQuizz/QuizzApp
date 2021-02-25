using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Services
{
 public  interface IQuizService
    {

        QuizReponse FindReponse(int quizId, int questionId, int repId);
       
        List<Quizz> FindAll();
        Quizz FindById(int quizId);
        List<QuizQuestion> FindQuizQuestion();
        void Delete(int id);
        void Insert(Quizz quiz);
        void SaveChanges();
        void Update(Quizz quiz);
    }
}
