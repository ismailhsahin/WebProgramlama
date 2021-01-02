using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebSonHal.Models;

namespace WebSonHal.Data
{
    public class ApplicationDbContext : IdentityDbContext<Admin>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Yazi> Yazi { get; set; }
        public DbSet<Yorum> Yorum { get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }
        public DbSet<Admin> Admin { get; set; }
    }
}
