using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuizApp.Models
{
    public class QuizReponse
    {
        public int Id { get; set; }
        public string RespText { get; set; }
        public bool IsCorrect { get; set; }

        [ForeignKey("QuizQuestionId")]
        public virtual QuizQuestion QuizQuestion { get; set; }

        public int QuizQuestionId { get; set; }

        public QuizReponse(string respText, bool isCorrect)
        {
            RespText = respText;
            IsCorrect = isCorrect;
        }

        public QuizReponse()
        {

        }
    }
}