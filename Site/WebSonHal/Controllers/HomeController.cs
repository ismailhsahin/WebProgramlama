using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebSonHal.Data;
using WebSonHal.Models;

namespace WebSonHal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IStringLocalizer<HomeController> localizer)
        {
            _context = context;
            _logger = logger;
            _localizer = localizer;
        }
        YaziYorum yy = new YaziYorum();

        public IActionResult YaziDetayIndex(int id)
        {
            yy.Deger1 = _context.Yazi.Where(x => x.Id == id).ToList();
            yy.Deger2 = _context.Yorum.Where(x => x.YaziId == id).ToList();

            return View(yy);
        }
        public IActionResult Index()
        {

            var db = _context.Yazi
                .Include(f => f.Kategori);
            return View(db.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CultureManagement(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });

            return RedirectToAction(nameof(Index));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
