using QuizApp.Models;
using QuizApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Services
{
    public class QuizReponseService : IQuizReponseService
    {
        private IQuizReponseRepository quizReponseRepository;

        public QuizReponseService(IQuizReponseRepository quizReponseRepository)
        {
            this.quizReponseRepository = quizReponseRepository;
        }

        public void Delete(int id)
        {
            quizReponseRepository.Delete(id);
        }

        public List<QuizReponse> FindReponse(int questionId)
        {
            return quizReponseRepository.FindReponse(questionId);
        }

        public QuizReponse FindReponseById(int ReponseId)
        {
            return quizReponseRepository.FindReponseById(ReponseId);
        }

        public List<QuizQuestion> FindQuestion(int questionId)
        {
            return quizReponseRepository.FindQuestion(questionId);
        }

        //public List<QuizQuestion> FindQuestion()
        //{
        //    return quizReponseRepository.FindQuestion();
        //}

        public void Insert(QuizReponse quizReponse)
        {
            quizReponseRepository.Insert(quizReponse);
        }

        public void SaveChanges()
        {
            quizReponseRepository.SaveChanges();
        }

        public void Update(QuizReponse quizReponse)
        {
            quizReponseRepository.FindReponseById(quizReponse.Id);

            quizReponseRepository.Update(quizReponse);
        }
    }
}
  