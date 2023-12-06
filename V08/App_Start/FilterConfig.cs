using System.Web;
using System.Web.Mvc;
using V08DataAccessLayer.Log;

namespace V08
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
