using QuizApp.Models;
using QuizApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Services
{
    public class QuizQuestionService : IQuizQuestionService
    {
        private IQuizQuestionRepository quizQuestionRepository;

        public QuizQuestionService(IQuizQuestionRepository quizQuestionRepository)
        {
            this.quizQuestionRepository = quizQuestionRepository;
        }

        public int CountQuestions(int quizId)
        {
            return quizQuestionRepository.CountQuestions(quizId);
        }

        public void Delete(int id)
        {
            quizQuestionRepository.Delete(id);
        }

        public List<QuizReponse> FindReponses()
        {
            return quizQuestionRepository.FindReponses().ToList();
        }

        public QuizQuestion FindQuestion(int quizId, int numOrder)
        {
            return quizQuestionRepository.FindQuestion(quizId, numOrder);
        }

        public QuizQuestion FindQuestionById(int questionId)
        {
            return quizQuestionRepository.FindQuestionById(questionId);
        }

        public List<Quizz> FindQuiz(int quizId)
        {
            return quizQuestionRepository.FindQuiz(quizId); ;
        }

        public void Insert(QuizQuestion quizQuestion)
        {
            quizQuestionRepository.Insert(quizQuestion);
        }

        public void SaveChanges()
        {
            quizQuestionRepository.SaveChanges();
        }

        public void Update(QuizQuestion quizQuestion)
        {
            quizQuestionRepository.FindQuestionById(quizQuestion.Id);

            quizQuestionRepository.Update(quizQuestion);
        }

        public List<QuizQuestion> FindAll()
        {
            return quizQuestionRepository.FindAll();
        }

        public List<QuizQuestion> FindAll(int page, int maxByPage, string searchField)
        {
            int start = (page - 1) * maxByPage;
            return quizQuestionRepository.FindAll(start, maxByPage, searchField);
        }

        public bool NextExist(int page, int maxByPage, string searchField)
        {
            return (page * maxByPage) < quizQuestionRepository.Count(searchField);
        }
    }
}
 