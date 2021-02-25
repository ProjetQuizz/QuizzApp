using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.Interceptors
{
    public class RolesFilter : ActionFilterAttribute
    {
        private UserRole[] authorizedRoles;

        public RolesFilter(params UserRole[] authorizedRoles)
        {
            this.authorizedRoles = authorizedRoles;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            string userR = filterContext.HttpContext.Session["user_role"].ToString();
            UserRole role = (UserRole)Enum.Parse(typeof(UserRole), userR);
            if (!authorizedRoles.Contains(role))
            {
                filterContext.Result = new RedirectToRouteResult(
               new System.Web.Routing.RouteValueDictionary
               {
                        {"controller","Home" },
                        {"action","Unauthorized" }
               }
               );
            }

        }
    }
}