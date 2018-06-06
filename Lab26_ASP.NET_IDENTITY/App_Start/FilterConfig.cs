using System.Web;
using System.Web.Mvc;

namespace Lab26_ASP.NET_IDENTITY
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
