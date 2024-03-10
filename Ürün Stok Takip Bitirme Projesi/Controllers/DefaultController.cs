using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ürün_Stok_Takip_Bitirme_Projesi.Controllers
{
    public class DefaultController : Controller
    {
        [Authorize]
        // GET: Default
        public ActionResult Cikis()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Anasayfa()

        {
            return View();
        }

    }
}