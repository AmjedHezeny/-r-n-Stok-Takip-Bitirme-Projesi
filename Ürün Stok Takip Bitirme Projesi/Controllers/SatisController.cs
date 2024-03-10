using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ürün_Stok_Takip_Bitirme_Projesi.Models.Entity;

namespace Ürün_Stok_Takip_Bitirme_Projesi.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        dbStokMVCEntities3 db = new dbStokMVCEntities3();
        public ActionResult Index()

        {
            List<SelectListItem> degerler = (from i in db.TBLURUNLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.URUNAD,
                                                 Value = i.URUNID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            List<SelectListItem> degerler2 = (from i in db.TBLMUSTERILER.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.MUSTERIAD + " " + i.MUSTERISOYAD,
                                                  Value = i.MUSTERIID.ToString()
                                              }).ToList();
            ViewBag.dgr2 = degerler2;
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR p1)
        {
            db.TBLSATISLAR.Add(p1);
            db.SaveChanges();
            return View("Index");
        }
    }
}