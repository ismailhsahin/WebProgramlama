using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Site.Data;
using Site.Models;

namespace Site.Controllers
{
    public class YaziController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public YaziController(ApplicationDbContext context,IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Yazi
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Yazi.Include(y => y.Kategori).Include(y => y.Kisi);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Yazi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yazi = await _context.Yazi
                .Include(y => y.Kategori)
                .Include(y => y.Kisi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yazi == null)
            {
                return NotFound();
            }

            return View(yazi);
        }

        // GET: Yazi/Create
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "CategoryName");
            ViewData["KisiId"] = new SelectList(_context.Kisi, "Id", "Name");
            return View();
        }

        // POST: Yazi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Icerik,Fotograf,OlusturulmaTarihi,TahminiOkumaSuresi,KategoriId,KisiId")] Yazi yazi)
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "Id", yazi.KategoriId);
            ViewData["KisiId"] = new SelectList(_context.Kisi, "Id", "Id", yazi.KisiId);
            return View(yazi);
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
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "Id", yazi.KategoriId);
            ViewData["KisiId"] = new SelectList(_context.Kisi, "Id", "Id", yazi.KisiId);
            return View(yazi);
        }

        // POST: Yazi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Icerik,Fotograf,OlusturulmaTarihi,TahminiOkumaSuresi,KategoriId,KisiId")] Yazi yazi)
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "Id", yazi.KategoriId);
            ViewData["KisiId"] = new SelectList(_context.Kisi, "Id", "Id", yazi.KisiId);
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
                .Include(y => y.Kisi)
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
            return RedirectToAction(nameof(Index));
        }

        private bool YaziExists(int id)
        {
            return _context.Yazi.Any(e => e.Id == id);
        }
    }
}
