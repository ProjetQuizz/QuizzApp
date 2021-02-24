using System;
using System.Data.Entity;
using System.Linq;

namespace QuizApp.Models
{
    public class MyContext : DbContext
    {

        public MyContext()
            : base("name=MyContext")
        {
        }

        public DbSet<Quiz> Quizs { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<QuizReponse> QuizReponses { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<QuizCategory> QuizCategories { get; set; }
    }

 
}