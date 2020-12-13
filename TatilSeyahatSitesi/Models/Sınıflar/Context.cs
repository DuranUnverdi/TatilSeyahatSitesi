using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TatilSeyahatSitesi.Models.Sınıflar
{
    public class Context: DbContext//veritabanı bağlantılarını model ilişki ayarları ve Object Materialization işlemi yapar
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdresBlog> AdresBlogs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public DbSet<İletişim> İletişims { get; set; }
        public DbSet<Yorumlar> Yorumlars { get; set; }

    }
}