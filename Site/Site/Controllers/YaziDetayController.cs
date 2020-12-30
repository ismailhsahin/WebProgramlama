using Microsoft.AspNetCore.Mvc;
using Site.Data;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Controllers
{
    public class YaziDetayController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YaziDetayController(ApplicationDbContext context)
        {
            _context = context;
        }
        YaziYorum yy = new YaziYorum();

        public IActionResult Index(int id)
        {
            yy.Deger1 = _context.Yazi.Where(x => x.Id == id).ToList();
            yy.Deger2 = _context.Yorum.Where(x => x.YaziId == id).ToList();

            return View(yy);
        }

    }
}
