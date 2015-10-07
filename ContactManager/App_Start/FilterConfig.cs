using System.Web;
using System.Web.Mvc;

namespace ContactManager
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            /* These filters prevent anonymous users from accessing any methods in the application.
               RequireHttps requires all access through HTTPS. */
            filters.Add(new HandleErrorAttribute());
            filters.Add(new System.Web.Mvc.AuthorizeAttribute());
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
