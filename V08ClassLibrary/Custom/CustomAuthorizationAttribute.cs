using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using V08ClassLibrary.Enum;
using V08DataAccessLayer.Entity;

namespace V08ClassLibrary.Custom
{
    public class CustomAuthorizationAttribute : ActionFilterAttribute
    {
        public EnumRole AuthorizedRole {  get; set; }

        public CustomAuthorizationAttribute(EnumRole roles) 
        {
            AuthorizedRole = roles;   
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Controller controller = filterContext.Controller as Controller;
            if (controller != null && controller.Session["Role"] != null) 
            {
                EnumRole sessionAccountRole = (EnumRole)controller.Session["Role"];
                EnumRole currentRole = sessionAccountRole;
                if (AuthorizedRole != currentRole)
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new { controller = "Error", action = "PagenotFound" }
                        )
                    );
                }
            }
        }
    }
}
