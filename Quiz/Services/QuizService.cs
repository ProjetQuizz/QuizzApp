using QuizApp.Models;
using QuizApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Services
{
    public class QuizService : IQuizService
    {
        private QuizRepository quizRepository;

        public QuizService(QuizRepository quizRepository)
        {
            this.quizRepository = quizRepository;
        }

        public void Delete(int id)
        {
            quizRepository.Delete(id);
        }

        public List<Quizz> FindAll()
        {
            return quizRepository.FindAll();
        }

        public Quizz FindById(int quizId)
        {
            return quizRepository.FindById(quizId);
        }

        public List<QuizQuestion> FindQuizQuestion()
        {
            return quizRepository.FindQuizQuestion();
        }

        public QuizReponse FindReponse(int quizId, int questionId, int repId)
        {

            return quizRepository.FindReponse(quizId, questionId, repId);  
        }

        public void Insert(Quizz quiz)
        {
            quizRepository.Insert(quiz);
        }

        public void SaveChanges()
        {
            quizRepository.SaveChanges();
        }

        public void Update(Quizz quiz)
        {
            quizRepository.FindById(quiz.Id);

            quizRepository.Update(quiz);
        }
    }
}
