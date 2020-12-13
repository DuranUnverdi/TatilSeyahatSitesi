using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSeyahatSitesi.Models.Sınıflar;
namespace TatilSeyahatSitesi.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            // var bloglar = c.Blogs.ToList();
            by.Deger1 = c.Blogs.ToList();
            // by.deger3 = c.Blogs.Take(3).ToList();
            by.Deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(by);
            
        }
        
        public ActionResult BlogDetay(int id)
        {

            // var blogbul = c.Blogs.Where(x => x.ID == id).ToList();//blog idsi ile dışarıdan göderilen parametre eşitse getirecek
            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();//hangi bloğa ait olduğunun tespiti
            by.Deger2 = c.Yorumlars.Where(x => x.Blogid == id).ToList();//bloğa ait yorumların çekilmesi
            return View(by);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
       public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
    }
}