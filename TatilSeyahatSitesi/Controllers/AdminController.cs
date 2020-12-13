using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSeyahatSitesi.Models.Sınıflar;

namespace TatilSeyahatSitesi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]//iki tane yeniblog olmasının sebebi birisi sayfanın yüklendiği anda calışacak
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]//sayfada birşey yaptığı zaman döndürme işlemini gerçekleştirecek
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);//ürettiğim nesneye parametreden gelen textboxfordaki  değerleri ekleyecez
            c.SaveChanges();//değişiklikleri kaydetmeye sağlıyor
                return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);//id den gelen değeri bulur
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");//değişim yapıldıktan sonra ındexte direkt değişime uğruyor
        }
        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir",bl);
        }
        public ActionResult BlogGüncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)//admin uygun görmediği yorumlarda değişiklik yapmasını sağlayacak 
        {
            var b = c.Yorumlars.Find(id);//id den gelen değeri bulur
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");//değişim yapıldıktan sonra  direkt değişime uğruyor
        }
        public ActionResult YorumGetir(int id)
        {
            var yorum = c.Yorumlars.Find(id);
            return View("YorumGetir", yorum);
        }
        public ActionResult YorumGüncelle(Yorumlar y)
        {
            var yorum = c.Yorumlars.Find(y.ID);
            yorum.KullaniciAdi = y.KullaniciAdi;
            yorum.Mail = y.Mail;
            yorum.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}