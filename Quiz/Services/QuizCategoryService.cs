using QuizApp.Models;
using QuizApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Services
{
    public class QuizCategoryService : IQuizCategoryService
    {
        private IQuizCategoryRepository quizCategoryRepository;

        public QuizCategoryService(IQuizCategoryRepository quizCategoryRepository)
        {
            this.quizCategoryRepository = quizCategoryRepository;
        }
        public void Delete(int id)
        {
            quizCategoryRepository.Delete(id);
        }

        public List<QuizCategory> FindAll(int page, int maxByPage, string searchField)
        {
            int start = (page - 1) * maxByPage;
            return quizCategoryRepository.FindAll(start, maxByPage, searchField);
        }

        public bool NextExist(int page, int maxByPage, string searchField)
        {
            return (page * maxByPage) < quizCategoryRepository.Count(searchField);
        }

        public QuizCategory FindCategoryById(int id)
        {
            return quizCategoryRepository.FindCategoryById(id);
        }

        public void Insert(QuizCategory quizCategory)
        {
            quizCategoryRepository.Insert(quizCategory);
        }

        public void SaveChanges()
        {
            quizCategoryRepository.SaveChanges();
        }

        public void Update(QuizCategory quizCategory)
        {
            quizCategoryRepository.Update(quizCategory);
        }
    }

}
