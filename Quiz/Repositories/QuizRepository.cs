using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuizApp.Repositories
{
    public class QuizRepository : IQuizRepository 
    {
            private MyContext db;
            internal DbSet<Quizz> dbSet;
            public QuizRepository(MyContext db)
            {
                this.db = db;
                dbSet = db.Set<Quizz>();
            }

            public void Delete(int id)
            {
                var quiz = db.Quizs.Find(id);
                if (quiz != null)
                {
                    db.Quizs.Remove(quiz);
                    db.Entry(quiz).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Questionnaire introuvable");
                }
            }


            public Quizz FindById(int quizId)
            {
                return db.Quizs.Find(quizId);
            }

            public List<Quizz> FindAll()
            {
                return db.Quizs.Include(qz => qz.Questions).AsNoTracking().ToList();

            }


            public void Insert(Quizz quiz)
            {

                db.Quizs.Add(quiz);
            }

            public void SaveChanges()
            {
                db.SaveChanges();
            }

            public void Update(Quizz quiz)
            {
                db.Entry(quiz).State = EntityState.Modified;
                db.SaveChanges();
            }

            public List<QuizQuestion> FindQuizQuestion()
            {
                return db.QuizQuestions.Include(q => q.Id).ToList();

            }

            public IQueryable<Quizz> Collection()
            {
                return dbSet;
            }

        public QuizReponse FindReponse(int quizId, int questionId, int repId)
        {
            return db.QuizReponses.AsNoTracking()
                             .SingleOrDefault(a => a.QuizQuestion.QuizId == quizId && a.QuizQuestion.Id == questionId && a.Id == repId);


        }
    }
       

 }