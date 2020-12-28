using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Site.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Kisi> Kisi { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Yazi> Yazi { get; set; }
        public DbSet<Yorum> Yorum { get; set; }
    }
}
