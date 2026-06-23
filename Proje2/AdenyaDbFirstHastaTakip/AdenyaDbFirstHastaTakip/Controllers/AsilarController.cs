using AdenyaDbFirstHastaTakip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AdenyaDbFirstHastaTakip.Controllers
{
    public class AsilarController : Controller
    {
        private readonly AppDbContext db;

        public AsilarController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index(string search)
        {
            var asilar = db.Asilar
                .Include(x => x.Hayvan)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                asilar = asilar.Where(x =>
                    x.AsiAdi.Contains(search) ||
                    x.Hayvan.HayvanAdi.Contains(search));
            }

            ViewBag.Search = search;

            return View(asilar.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.HayvanId = new SelectList(db.Hayvanlar.ToList(), "Id", "HayvanAdi");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Asilar asi)
        {
            db.Asilar.Add(asi);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var asi = db.Asilar.Find(id);

            if (asi == null)
                return NotFound();

            ViewBag.HayvanId = new SelectList(db.Hayvanlar.ToList(), "Id", "HayvanAdi", asi.HayvanId);

            return View(asi);
        }

        [HttpPost]
        public IActionResult Edit(Asilar asi)
        {
            db.Asilar.Update(asi);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var asi = db.Asilar.Find(id);

            if (asi == null)
                return NotFound();

            db.Asilar.Remove(asi);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}