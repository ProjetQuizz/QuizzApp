using QuizApp.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    [LoginFilter]
    public class AdminSpaceController : Controller
    {
        // GET: AdminSpace
        public ActionResult Index()
        {
            return View();
        }
    }
}