using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyonProjesi.Models.Siniflar;

namespace TicariOtomasyonProjesi.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index()
        {
            Class2 cs = new Class2();
           // var degerler = c.Uruns.Where(x => x.Urunid == 1).ToList();
           cs.Deger1= c.Uruns.Where(x => x.Urunid == 1).ToList();
            cs.Deger2= c.Class1s.Where(x => x.DetayID == 1).ToList();
            return View(cs);
        }
    }
}