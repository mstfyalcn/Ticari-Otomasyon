using TicariOtomasyonProjesi.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicariOtomasyonProjesi.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var k = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(y => y.TakipKodu.Contains(p));    //Contains karakteri içeren tüm değerleri bulmamıza yarar
            }
            return View(k.ToList());
        }

        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random rnd = new Random();
            string[] karakter = { "X", "Y", "A", "Z","D"};
            int k1, k2, k3;
            k1 = rnd.Next(0, karakter.Length);
            k2 = rnd.Next(0, karakter.Length);
            k3 = rnd.Next(0, karakter.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 999);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);

            string kod = karakter[k1] +s1.ToString() + karakter[k2] + s2.ToString() + karakter[k3] + s3.ToString();
            ViewBag.takipkod = kod;
            return View();
        }

        [HttpPost]
        public ActionResult YeniKargo(KargoDetay d)
        {
            c.KargoDetays.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult KargoTakip(string id)
        {
            var deger = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
           
            return View(deger);
        }
    }
}