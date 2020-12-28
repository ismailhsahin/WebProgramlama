using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Site.Data;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {

            var db = _context.Yazi
                .Include(f => f.Kisi)
                .Include(f => f.Kategori);


            return View(db.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        YaziYorum yy = new YaziYorum();
        public IActionResult YaziDetay(int id)
        {
            //var blogbul = _context.Yazi.Where(x => x.Id == id).ToList();
            yy.Deger1 = _context.Yazi.Where(x => x.Id == id).ToList();
            yy.Deger2 = _context.Yorum.Where(x => x.Id == id).ToList();
            return View(yy);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
