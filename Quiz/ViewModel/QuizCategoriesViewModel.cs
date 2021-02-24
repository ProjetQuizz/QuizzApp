using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.ViewModel
{
    public class QuizCategoriesViewModel
    {
        public Models.Quiz Quiz { get; set; }
        public IEnumerable<QuizCategory> QuizCategories { get; set; }
    }
}