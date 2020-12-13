using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSeyahatSitesi.Models.Sınıflar;

namespace TatilSeyahatSitesi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Context c = new Context();//yardımcı nesne türetiyoruz
        public ActionResult Index()
        {
            var degerler = c.Hakkimizdas.ToList();//contexte bağlı olan sınıflar içerisindeki hakkimizdaki tabloya ulaştık ulaştık
            return View(degerler);
        }
    }
}