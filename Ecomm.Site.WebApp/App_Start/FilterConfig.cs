using Ecomm.Site.WebApp.Extension.Filter;
using System.Web;
using System.Web.Mvc;

namespace Ecomm.Site.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
			filters.Add(new ElmahErrorAttribute());
        }
    }
}
