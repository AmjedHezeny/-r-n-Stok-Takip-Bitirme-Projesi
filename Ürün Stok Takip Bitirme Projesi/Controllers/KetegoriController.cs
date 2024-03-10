using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ürün_Stok_Takip_Bitirme_Projesi.Controllers;
using Ürün_Stok_Takip_Bitirme_Projesi.Models.Entity;


namespace StokMVC.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        dbStokMVCEntities3 db = new dbStokMVCEntities3();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.TBLKATEGORILER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            TBLKATEGORILER kategori = db.TBLKATEGORILER.Find(id);

            var urunler = db.TBLURUNLER.Where(u => u.URUNKATEGORI == id).ToList();

            if (urunler.Count > 0)
            {
                foreach (var urun in urunler)
                {
                    db.TBLURUNLER.Remove(urun);
                }

                db.SaveChanges();
            }

            db.TBLKATEGORILER.Remove(kategori);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORILER.Find(id);
            return View("KategoriGetir", ktgr);
        }

        public ActionResult Guncelle(TBLKATEGORILER p1)
        {
            var ktgr = db.TBLKATEGORILER.Find(p1.KATEGORIID);
            ktgr.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}