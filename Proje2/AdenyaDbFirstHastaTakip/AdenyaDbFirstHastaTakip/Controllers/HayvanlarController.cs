using AdenyaDbFirstHastaTakip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AdenyaDbFirstHastaTakip.Controllers
{
    public class HayvanlarController : Controller
    {
        private readonly AppDbContext db;

        public HayvanlarController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index(string search)
        {
            var hayvanlar = db.Hayvanlar
                .Include(x => x.Sahip)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                hayvanlar = hayvanlar.Where(x =>
                    x.HayvanAdi.Contains(search) ||
                    x.Tur.Contains(search) ||
                    x.Sahip.AdSoyad.Contains(search));
            }

            ViewBag.Search = search;

            return View(hayvanlar.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.SahipId = new SelectList(db.Sahipler.ToList(), "Id", "AdSoyad");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hayvanlar hayvan)
        {
            db.Hayvanlar.Add(hayvan);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var hayvan = db.Hayvanlar.Find(id);

            if (hayvan == null)
            {
                return NotFound();
            }

            ViewBag.SahipId = new SelectList(db.Sahipler.ToList(), "Id", "AdSoyad", hayvan.SahipId);

            return View(hayvan);
        }

        [HttpPost]
        public IActionResult Edit(Hayvanlar hayvan)
        {
            db.Hayvanlar.Update(hayvan);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var hayvan = db.Hayvanlar.Find(id);

            if (hayvan == null)
            {
                return NotFound();
            }

            db.Hayvanlar.Remove(hayvan);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}