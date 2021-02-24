using QuizApp.Models;
using QuizApp.Repositories;
using QuizApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class TestDataController : Controller
    {
        // GET: TestData
        private MyContext db = new MyContext();
        private IUserService userService;

        public TestDataController()
        {
            userService = new UserService(new UserRepository(db));
        }

        // GET: TestData
        // /TestData/InsertTestData
        public ActionResult InsertTestData()
        {


            for (int i = 1; i <= 10; i++)
            {
                Utilisateur u = new Utilisateur
                {
                    Name = "admin" + i,
                    Email = "admin" + i + "@dawan.fr",
                    Password = "admin" + i,
                    Role = UserRole.ADMIN
                };
                userService.Save(u);
            }

            for (int i = 1; i <= 10; i++)
            {
                string strP = "user" + i;
                Utilisateur u = new Utilisateur
                {
                    Name = "user" + i,
                    Email = "user" + i + "@dawan.fr",
                    Password = strP,
                    Role = UserRole.USER
                };
                userService.Save(u);
            }
            return View("Index");
        }
    }
}