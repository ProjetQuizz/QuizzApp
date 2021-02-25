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
    [RoutePrefix("Login")]
    [Route("{action=Connexion}")]
    public class LoginController : Controller
    {
        private MyContext db = new MyContext();
        
        private IUserService userService;
       public LoginController()
        {
            userService = new UserService(new UserRepository(db));
        }

        [HttpGet]
        [Route("Connexion")]
        public ActionResult Connexion()
            {
                return View("Connexion");
            }


            [HttpPost]
            [Route("Connexion")]
            [ValidateAntiForgeryToken]
            public ActionResult Connexion(Utilisateur u)
            {
                try
                {
                    Utilisateur userInDb = userService.CheckLogin(u.Email, u.Password);
                    if (userInDb != null)
                    {
                        Session["user_id"] = userInDb.Id;
                        Session["user_connected"] = true;
                        Session["user_role"] = userInDb.Role.ToString();
                        Session["user_name"] = userInDb.Name;


                        switch (userInDb.Role)
                        {
                            case UserRole.ADMIN:
                                return RedirectToAction("Index", "AdminSpace");
                            case UserRole.USER:
                                return RedirectToAction("Index", "UserSpace");
                        }

                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Msg = ex.Message;
                   
                }

                return View("Connexion", u);
        }

            public ActionResult Logout()
            {
                Session.Abandon();
                return RedirectToAction("Index", "Home");
            }
        
      }
}