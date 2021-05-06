﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyonProjesi.Models.Siniflar;

namespace TicariOtomasyonProjesi.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.Uruns.Sum(x=>x.Stok).ToString();
            ViewBag.d5 = deger5;
            //ürünler içinden markaları "farklı olanları" seç sayısını yaz
            var deger6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = c.Uruns.Count(x=>x.Stok<=10).ToString();
            ViewBag.d7 = deger7;

            //orderby ile sırala descending ile küçükten büyüğe sırala firstordefault ile yakala select ile seç ve yaz
            var deger8 = (from x in c.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;

            //orderby ile sırala ascending büyükten küçüğe sırala firstordefault ile yakala select ile seç ve yaz
            var deger9 = (from x in c.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = c.Uruns.Count(x=>x.UrunAd=="Cep Telefonu").ToString();
            ViewBag.d10 = deger10;
            var deger11 = c.Uruns.Count(x=>x.UrunAd=="Ipad").ToString();
            ViewBag.d11 = deger11;

            //ürünleri markasına göre grupla, her grubu count olarak büyükten küçüğe sırala,ismi  en çok geçeni seç
            var deger12 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.d12 = deger12;

            //satışharekets içindekileri ürünid ye göre gruplandırıp büyükten küçüğe sırala, en büyük olanın id'sine göre adını bul ve seç ve onu bana yazdır
            var deger13 = c.Uruns.Where(x => x.Urunid == (c.SatisHarekets.GroupBy(y => y.Urunid).OrderByDescending(z => z.Count()).Select(d => d.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14 = c.SatisHarekets.Sum(x =>x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;

            DateTime bugun = DateTime.Today;
            var deger15 = c.SatisHarekets.Count(x=>x.Tarih==bugun).ToString();
            ViewBag.d15 = deger15;
            var deger16 = c.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y =>(decimal?) y.ToplamTutar).ToString();
            ViewBag.d16 = deger16;
            return View();
        }

        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Carilers
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }

        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.DepartmanAd into g
                         select new SinifGrup2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult Partial2()
        {
            var sorgu = c.Carilers.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial3()
        {
            var sorgu = c.Uruns.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial4()
        {
            var sorgu2 = from x in c.Uruns
                         group x by x.Marka into g
                         select new SinifGrup3
                         {
                             marka = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
    }
}