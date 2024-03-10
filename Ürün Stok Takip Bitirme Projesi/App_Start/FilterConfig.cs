using System.Web;
using System.Web.Mvc;

namespace Ürün_Stok_Takip_Bitirme_Projesi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
