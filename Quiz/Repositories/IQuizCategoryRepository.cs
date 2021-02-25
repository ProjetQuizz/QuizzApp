using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Repositories
{
   public interface IQuizCategoryRepository
    {
        List<QuizCategory> FindAll(int start, int max, string searchField);
        //List<QuizCategory> FindAll();
        int Count(string searchField);
        QuizCategory FindCategoryById(int id);
        void Delete(int id);
        void Insert(QuizCategory quizCategory);
        void SaveChanges();
        void Update(QuizCategory quizCategory);
    }
}
