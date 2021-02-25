using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuizApp.Repositories
{
    public class QuizReponseRepository : IQuizReponseRepository
    {
        private MyContext db;

        public QuizReponseRepository(MyContext db)
        {
            this.db = db;
        }
        public void Delete(int id)
        {
            var a = db.QuizReponses.Find(id);
            if (a != null)
            {
                db.QuizReponses.Remove(a);
                db.Entry(a).State = EntityState.Deleted;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Reponse introuvable");
            }
        }

        public List<QuizReponse> FindReponse(int questionId)
        {
            return db.QuizReponses.AsNoTracking().Where(r => r.QuizQuestionId == questionId).ToList();

        }

        public QuizReponse FindReponseById(int ReponseId)
        {
            return db.QuizReponses.Find(ReponseId);
        }

        public List<QuizQuestion> FindQuestion(int questionId)
        {

            return db.QuizQuestions.Include(q => q.Id == questionId).ToList();

        }

        public void Insert(QuizReponse quizReponse)
        {
            db.QuizReponses.Add(quizReponse);

        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(QuizReponse quizReponse)
        {
            db.Entry(quizReponse).State = EntityState.Modified;
            db.SaveChanges();
        }

        
    }
}