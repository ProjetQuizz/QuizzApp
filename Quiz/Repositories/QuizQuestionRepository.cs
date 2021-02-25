using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuizApp.Repositories
{
    public class QuizQuestionRepository : IQuizQuestionRepository
    {

        private MyContext db;
       
        public QuizQuestionRepository(MyContext db)
        {
            this.db = db;
  

        }
        public int CountQuestions(int quizId)
        {
            return (from q in db.Quizs.AsNoTracking() where q.Id == quizId select q).Count();

        }

        public void Delete(int id)
        {
            //db.QuizQuestions.Remove(db.QuizQuestions.Find(id));
            //db.SaveChanges();

            var qst = db.QuizQuestions.Find(id);
            if (qst != null)
            {
                db.QuizQuestions.Remove(qst);
               
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Question introuvable");
            }
        }

        public QuizQuestion FindQuestionById(int questionId)
        {
            return db.QuizQuestions.AsNoTracking().SingleOrDefault(qst => qst.Id == questionId);
        }




        public List<QuizReponse> FindReponses()
        {
            return db.QuizReponses.Include(q => q.Id).ToList();
        }

        public void Insert(QuizQuestion quizQuestion)
        {
            db.QuizQuestions.Add(quizQuestion);
            db.SaveChanges();

        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(QuizQuestion quizQuestion)
        {
            db.Entry(quizQuestion).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<Quizz> FindQuiz(int quizId)
        {
            return db.Quizs.Include(q => q.Id == quizId).ToList();
        }

      
        public QuizQuestion FindQuestion(int quizId, int numOrder)
        {

            return db.QuizQuestions.Include(qst=>qst.Reponses).AsNoTracking()
                              .SingleOrDefault(qst => qst.QuizId == quizId && qst.NumOrdrer == numOrder);

           


        }

        public List<QuizQuestion> FindAll()
        {
            return db.QuizQuestions.AsNoTracking().ToList();
        }

        public List<QuizQuestion> FindAll(int start, int max, string searchField)
        {
            IQueryable<QuizQuestion> req = db.QuizQuestions.AsNoTracking().OrderBy(u => u.QstText);
            if (searchField != null && !searchField.Trim().Equals(""))
            {
                req = req.Where(u => u.QstText.ToLower().Contains(searchField));
            }
            req = req.Skip(start).Take(max);
            return req.ToList();
        }

        public int Count(string searchField)
        {
            IQueryable<QuizQuestion> req = db.QuizQuestions.AsNoTracking();
            if (searchField != null && !searchField.Trim().Equals(""))
            {
                req = req.Where(u => u.QstText.ToLower().Contains(searchField));
            }
            return req.Count();
        }
    }
}
