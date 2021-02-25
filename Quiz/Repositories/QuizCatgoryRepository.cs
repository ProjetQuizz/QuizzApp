using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuizApp.Repositories
{
           public class QuizCategoryRepository : IQuizCategoryRepository
           {
                private MyContext db;
            
           public QuizCategoryRepository(MyContext db)
             {
                this.db = db;
                
             }

     
        public void Delete(int id)
            {
                var category = db.QuizCategories.Find(id);
                if (category != null)
                {
                    db.QuizCategories.Remove(category);
                    db.Entry(category).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Category introuvable");
                }
            }

        //public List<QuizCategory> FindAll()
        //{
        //    return db.QuizCategories.AsNoTracking().ToList();
        //}

        public List<QuizCategory> FindAll(int start, int max, string searchField)
        {
            IQueryable<QuizCategory> req = db.QuizCategories.AsNoTracking().OrderBy(u => u.Category);
            if (searchField != null && !searchField.Trim().Equals(""))
            {
                req = req.Where(u => u.Category.ToLower().Contains(searchField));
            }
            req = req.Skip(start).Take(max);
            return req.ToList();
        }


        public int Count(string searchField)
        {
            IQueryable<QuizCategory> req = db.QuizCategories.AsNoTracking();
            if (searchField != null && !searchField.Trim().Equals(""))
            {
                req = req.Where(u => u.Category.ToLower().Contains(searchField));
            }
            return req.Count();
        }



        public QuizCategory FindCategoryById(int id)
                {
                return db.QuizCategories.AsNoTracking().SingleOrDefault(c => c.Id == id);
                }

        public void Insert(QuizCategory quizCategory)
        {
            db.QuizCategories.Add(quizCategory);
            db.SaveChanges();

        }
        public void SaveChanges()
        { 
           db.SaveChanges();
        }

        public void Update(QuizCategory quizCategory)
         {

           db.Entry(quizCategory).State = EntityState.Modified;
           db.SaveChanges();
        }


    
   }
}

