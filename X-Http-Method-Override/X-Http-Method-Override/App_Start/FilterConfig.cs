using System.Web;
using System.Web.Mvc;

namespace X_Http_Method_Override
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
