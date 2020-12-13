using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TatilSeyahatSitesi.Models.Sınıflar
{
    public class BlogYorum//biren fazla tablodan veri çekmek için oluşturduk
    {
        public IEnumerable<Blog> Deger1 { get; set; }//belli sayıdaki değerleri koleksiyon şeklinde toplamaya yarar
        public IEnumerable<Yorumlar> Deger2 { get; set; }
        public IEnumerable<Blog> Deger3 { get; set; }
    }
}