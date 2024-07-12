using System.Web;
using System.Web.Mvc;

namespace idc_costshare_jupiter_api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
