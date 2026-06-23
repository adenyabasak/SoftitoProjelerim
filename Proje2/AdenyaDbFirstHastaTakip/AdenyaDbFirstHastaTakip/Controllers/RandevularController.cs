using AdenyaDbFirstHastaTakip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AdenyaDbFirstHastaTakip.Controllers
{
    public class RandevularController : Controller
    {
        private readonly AppDbContext db;

        public RandevularController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index(string search)
        {
            var randevular = db.Randevular
                .Include(x => x.Hayvan)
                .Include(x => x.Veteriner)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                randevular = randevular.Where(x =>
                    x.Hayvan.HayvanAdi.Contains(search) ||
                    x.Veteriner.AdSoyad.Contains(search) ||
                    x.RandevuDurumu.Contains(search));
            }

            ViewBag.Search = search;

            return View(randevular.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.HayvanId = new SelectList(db.Hayvanlar.ToList(), "Id", "HayvanAdi");
            ViewBag.VeterinerId = new SelectList(db.Veterinerler.ToList(), "Id", "AdSoyad");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Randevular randevu)
        {
            db.Randevular.Add(randevu);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var randevu = db.Randevular.Find(id);

            if (randevu == null)
                return NotFound();

            ViewBag.HayvanId = new SelectList(db.Hayvanlar.ToList(), "Id", "HayvanAdi", randevu.HayvanId);
            ViewBag.VeterinerId = new SelectList(db.Veterinerler.ToList(), "Id", "AdSoyad", randevu.VeterinerId);

            return View(randevu);
        }

        [HttpPost]
        public IActionResult Edit(Randevular randevu)
        {
            db.Randevular.Update(randevu);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var randevu = db.Randevular.Find(id);

            if (randevu == null)
                return NotFound();

            db.Randevular.Remove(randevu);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}