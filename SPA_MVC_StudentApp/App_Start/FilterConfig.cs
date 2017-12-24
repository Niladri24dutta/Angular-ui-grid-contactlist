using System.Web;
using System.Web.Mvc;

namespace SPA_MVC_StudentApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
