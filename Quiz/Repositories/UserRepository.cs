using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private MyContext db;

        public UserRepository(MyContext db)
        {
            this.db = db;
        }

        public List<Utilisateur> FindAll(int start, int max, string searchField)
        {
            IQueryable<Utilisateur> req = db.Utilisateurs.AsNoTracking().OrderBy(u => u.Name);
            if(searchField!=null && !searchField.Trim().Equals(""))
            {
                req = req.Where(u => u.Name.ToLower().Contains(searchField)
                         || u.Email.ToLower().Contains(searchField));
            }
            req = req.Skip(start).Take(max);
            return req.ToList();
        }

        public int Count(string searchField)
        {
            IQueryable<Utilisateur> req = db.Utilisateurs.AsNoTracking();
            if (searchField != null && !searchField.Trim().Equals(""))
            {
                req = req.Where(u => u.Name.ToLower().Contains(searchField)
                         || u.Email.ToLower().Contains(searchField));
            }
            return req.Count();
        }

        public void Delete(int? id)
        {
            db.Utilisateurs.Remove(db.Utilisateurs.Find(id));
            db.SaveChanges();
        }

     

        public Utilisateur FindByEmail(string email)
        {
            return db.Utilisateurs.SingleOrDefault(u => u.Email.Equals(email));
        }

        public Utilisateur FindById(int? id)
        {
            return db.Utilisateurs.AsNoTracking().SingleOrDefault(u => u.Id == id);
        }

        public void Save(Utilisateur u)
        {
            db.Utilisateurs.Add(u);
            db.SaveChanges();
        }

        public void Update(Utilisateur u)
        {
            db.Entry(u).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}