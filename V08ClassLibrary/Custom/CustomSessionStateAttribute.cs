﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace V08ClassLibrary.Custom
{
    public class CustomSessionStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Controller controller = filterContext.Controller as Controller;
            if (controller != null && controller.Session["EmployeeId"] == null )
            {
                filterContext.Result = new RedirectToRouteResult(
                       new RouteValueDictionary(
                           new { controller = "Account", action = "LogInPage" }
                       )
                   );
            }
        }
    }
}
