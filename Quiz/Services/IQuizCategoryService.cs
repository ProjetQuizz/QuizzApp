using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Services
{
 public  interface IQuizCategoryService
    {
        //List<QuizCategory> FindAll();
        List<QuizCategory> FindAll(int page, int maxByPage, string searchField);
        bool NextExist(int page, int maxByPage, string searchField);

        QuizCategory FindCategoryById(int id);
        void Delete(int id);
        void Insert(QuizCategory quizCategory);
        void SaveChanges();
        void Update(QuizCategory quizCategory);
    }
}
