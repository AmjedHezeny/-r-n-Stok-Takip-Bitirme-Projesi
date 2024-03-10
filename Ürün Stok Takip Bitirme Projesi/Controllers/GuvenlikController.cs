using Ürün_Stok_Takip_Bitirme_Projesi.Models.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using System.Web.Security;

namespace Ürün_Stok_Takip_Bitirme_Projesi.Controllers
{
    public class GuvenlikController : Controller
    {
        dbStokMVCEntities3 db = new dbStokMVCEntities3();

        public ActionResult GirisYap()
        {
            return View();
        }

        public enum AlertEnum
        {
            danger,
        }

        [HttpPost]
        public ActionResult GirisYap(TBKULLANCILAR t)
        {
            var bilgiler = db.TBKULLANCILAR.FirstOrDefault(x => x.AD == t.AD && x.SIFRA == t.SIFRA);
            if (bilgiler != null)
            {
             
                Session["bilgiler"] = bilgiler.ID;

                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();

                return RedirectToAction("Anasayfa", "Default");
            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı adı veya şifre hatalı";
                ViewBag.AlertEnum = AlertEnum.danger;
                return View();
            }
        }

        public ActionResult CikisYap()
        {
            if (Session["bilgiler"] != null)
            {
                Session.Remove("bilgiler");
            }
            Session.Abandon();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return RedirectToAction("GirisYap");
        }
    }
}
