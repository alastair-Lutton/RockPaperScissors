using System.Web;
using System.Web.Mvc;

namespace Game___RockPaperScissors
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
