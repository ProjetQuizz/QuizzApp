using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Repositories
{
    public interface IUserRepository
    {
        List<Utilisateur> FindAll(int start, int max, string searchField);
        Utilisateur FindByEmail(string email);
        int Count(string searchField);
        void Save(Utilisateur u);
        Utilisateur FindById(int? id);
        void Update(Utilisateur u);
        void Delete(int? id);
    }
}
