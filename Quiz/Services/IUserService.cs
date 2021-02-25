using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Services
{
  public interface IUserService
    {
        Utilisateur CheckLogin(string email, string password);
        List<Utilisateur> FindAll(int page, int maxByPage, string searchField);
        bool NextExist(int page, int maxByPage, string searchField);
        void Save(Utilisateur user);
        Utilisateur Find(int? id);
        void Update(Utilisateur user);
        void Remove(int id);
    }
}

