using QuizApp.Models;
using QuizApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationMES.Tools;

namespace QuizApp.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Utilisateur CheckLogin(string email, string password)
        {
            string errorMsg = "Erreur : identifiants incorrects !";
            Utilisateur u = _userRepository.FindByEmail(email);

            if (u == null)
                throw new Exception(errorMsg);

            string hashedPwd = HashTools.ComputeSha256Hash(password);
            if (!u.Password.Equals(hashedPwd))
                throw new Exception(errorMsg);

            return u;
        }

        public Utilisateur Find(int? id)
        {
            return _userRepository.FindById(id);
        }

        public List<Utilisateur> FindAll(int page, int maxByPage, string searchField)
        {
            int start = (page - 1) * maxByPage;
            return _userRepository.FindAll(start, maxByPage, searchField);
        }

        public bool NextExist(int page, int maxByPage, string searchField)
        {
            return (page * maxByPage) < _userRepository.Count(searchField);
        }

        public void Remove(int id)
        {
            _userRepository.Delete(id);
        }

        public void Save(Utilisateur user)
        {
            user.Password = HashTools.ComputeSha256Hash(user.Password);
            _userRepository.Save(user);
        }

        public void Update(Utilisateur user)
        {
            Utilisateur x = _userRepository.FindById(user.Id);
            if (!x.Password.Equals(user.Password))
            {
                user.Password = HashTools.ComputeSha256Hash(user.Password);
            }
            _userRepository.Update(user);
        }
    }
}