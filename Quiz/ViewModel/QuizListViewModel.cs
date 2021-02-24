using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.ViewModel
{
    public class QuizListViewModel
    {
        public List<Models.Quiz> Quizs { get; set; }
        public List<QuizCategory> QuizCategories { get; set; }
    }
}