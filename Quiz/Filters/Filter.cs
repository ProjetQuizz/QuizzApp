using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.Filters
{
    public class Filter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["user"] == null)
            {
                //option 1:
                filterContext.HttpContext.Response.Redirect("~/Login/Connexion");// /Controller/Action

                //option 2 :
                //filterContext.Result = new RedirectResult("~/Login/Index");
            }
        }
    }
}