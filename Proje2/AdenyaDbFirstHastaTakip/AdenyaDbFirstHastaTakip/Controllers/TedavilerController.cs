using AdenyaDbFirstHastaTakip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AdenyaDbFirstHastaTakip.Controllers
{
    public class TedavilerController : Controller
    {
        private readonly AppDbContext db;

        public TedavilerController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index(string search)
        {
            var tedaviler = db.Tedaviler
                .Include(x => x.Hayvan)
                .Include(x => x.Veteriner)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                tedaviler = tedaviler.Where(x =>
                    x.TedaviAdi.Contains(search) ||
                    x.Hayvan.HayvanAdi.Contains(search) ||
                    x.Veteriner.AdSoyad.Contains(search));
            }

            ViewBag.Search = search;

            return View(tedaviler.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.HayvanId = new SelectList(db.Hayvanlar.ToList(), "Id", "HayvanAdi");
            ViewBag.VeterinerId = new SelectList(db.Veterinerler.ToList(), "Id", "AdSoyad");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tedaviler tedavi)
        {
            db.Tedaviler.Add(tedavi);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var tedavi = db.Tedaviler.Find(id);

            if (tedavi == null)
                return NotFound();

            ViewBag.HayvanId = new SelectList(db.Hayvanlar.ToList(), "Id", "HayvanAdi", tedavi.HayvanId);
            ViewBag.VeterinerId = new SelectList(db.Veterinerler.ToList(), "Id", "AdSoyad", tedavi.VeterinerId);

            return View(tedavi);
        }

        [HttpPost]
        public IActionResult Edit(Tedaviler tedavi)
        {
            db.Tedaviler.Update(tedavi);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var tedavi = db.Tedaviler.Find(id);

            if (tedavi == null)
                return NotFound();

            db.Tedaviler.Remove(tedavi);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}