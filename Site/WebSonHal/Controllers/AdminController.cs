using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSonHal.Data;
using WebSonHal.Models;

namespace WebSonHal.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AdminController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var degerler = _context.Yazi.ToList();
            return View(degerler);
        }

        
        


        public ActionResult YorumListesi()
        {
            var yorumlar = _context.Yorum.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var b = _context.Yorum.Find(id);
            _context.Yorum.Remove(b);
            _context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }


        public async Task<IActionResult> YorumDuzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorum.FindAsync(id);
            if (yorum == null)
            {
                return NotFound();
            }
            ViewData["YaziId"] = new SelectList(_context.Yazi, "Id", "Id", yorum.YaziId);
            return View(yorum);
        }

        // POST: Yazi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YorumDuzenle(int id, [Bind("Id,Isim,Mail,YorumIcerik,YaziId")] Yorum yorum)
        {
            if (id != yorum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yorum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YaziExists(yorum.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("YorumListesi");
            }
            ViewData["YaziId"] = new SelectList(_context.Yazi, "Id", "Id", yorum.YaziId);
            return View(yorum);
        }



        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "CategoryName");
            return View();
        }
        // POST: Yazi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Icerik,Fotograf,OlusturulmaTarihi,KategoriId")] Yazi yazi)
        {
            if (ModelState.IsValid)
            {

                //******
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;


                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"image\yazi");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                yazi.Fotograf = @"\image\yazi\" + fileName + extension;

                //********

                _context.Add(yazi);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "Id", yazi.KategoriId);
            return View(yazi);
        }





        YaziYorum yy = new YaziYorum();
        // GET: Yazi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            yy.Deger1 = _context.Yazi.Where(x => x.Id == id).ToList();
            yy.Deger2 = _context.Yorum.Where(x => x.YaziId == id).ToList();

            return View(yy);
        }


        // GET: Yazi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yazi = await _context.Yazi.FindAsync(id);
            if (yazi == null)
            {
                return NotFound();
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "CategoryName", yazi.KategoriId);
            return View(yazi);
        }

        // POST: Yazi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Icerik,Fotograf,OlusturulmaTarihi,KategoriId")] Yazi yazi)
        {
            if (id != yazi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yazi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YaziExists(yazi.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "Id", yazi.KategoriId);
            return View(yazi);
        }

        // GET: Yazi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yazi = await _context.Yazi
                .Include(y => y.Kategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yazi == null)
            {
                return NotFound();
            }

            return View(yazi);
        }

        // POST: Yazi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yazi = await _context.Yazi.FindAsync(id);
            _context.Yazi.Remove(yazi);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool YaziExists(int id)
        {
            return _context.Yazi.Any(e => e.Id == id);
        }

    }
}
