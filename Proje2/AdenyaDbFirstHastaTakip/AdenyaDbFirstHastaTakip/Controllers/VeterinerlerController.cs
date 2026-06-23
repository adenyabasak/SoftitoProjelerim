using AdenyaDbFirstHastaTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdenyaDbFirstHastaTakip.Controllers
{
    public class VeterinerlerController : Controller
    {
        private readonly AppDbContext db;

        public VeterinerlerController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index(string search)
        {
            var veterinerler = db.Veterinerler.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                veterinerler = veterinerler.Where(x =>
                    x.AdSoyad.Contains(search) ||
                    x.Uzmanlik.Contains(search) ||
                    x.Telefon.Contains(search));
            }

            ViewBag.Search = search;

            return View(veterinerler.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Veterinerler veteriner)
        {
            db.Veterinerler.Add(veteriner);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var veteriner = db.Veterinerler.Find(id);

            if (veteriner == null)
            {
                return NotFound();
            }

            return View(veteriner);
        }

        [HttpPost]
        public IActionResult Edit(Veterinerler veteriner)
        {
            db.Veterinerler.Update(veteriner);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var veteriner = db.Veterinerler.Find(id);

            if (veteriner == null)
            {
                return NotFound();
            }

            db.Veterinerler.Remove(veteriner);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}