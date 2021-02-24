using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuizApp.Models
{
    public class QuizQuestion
    {
        public int Id { get; set; }
        public string QstText { get; set; }
        public bool IsMultiple { get; set; }
        public int NumOrdrer { get; set; }

        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }
        public int QuizId { get; set; }
        public virtual List<QuizReponse> Reponses { get; set; }

        public QuizQuestion()
        {
            Reponses = new List<QuizReponse>();
        }

        public QuizQuestion(string QstText, bool IsMultiple, int NomOrder)
        {
            this.QstText = QstText;
            this.IsMultiple = IsMultiple;
            this.NumOrdrer = NumOrdrer;
            Reponses = new List<QuizReponse>();
        }
    }
}