using QuizApp.Interceptors;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    [LoginFilter]
    [RolesFilter(UserRole.USER)]
    public class UserSpaceController : Controller
    {
        // GET: UserSpace
        public ActionResult Index()
        {
            return View();
        }
    }
}