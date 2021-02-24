using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public virtual List<QuizQuestion> Questions { get; set; }
        public string Description { get; set; }

        public string Category { get; set; }
        public Quiz()
        {
            Questions = new List<QuizQuestion>();
          
        }

        public Quiz(string Subject)
        {
            Questions = new List<QuizQuestion>();
            this.Subject = Subject;
        }
    }
}