using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //To apply global filters for all classes
            //This filter redirects to an error page when exceptions occur
            filters.Add(new HandleErrorAttribute());
            //Stops users accessing the customers and movies without logging in first
            filters.Add(new AuthorizeAttribute());
            //App endpoints will not work on http 
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
