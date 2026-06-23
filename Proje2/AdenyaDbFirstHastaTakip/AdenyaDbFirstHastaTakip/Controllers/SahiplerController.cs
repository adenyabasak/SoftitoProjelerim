using AdenyaDbFirstHastaTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdenyaDbFirstHastaTakip.Controllers
{
    public class SahiplerController : Controller
    {
        private readonly AppDbContext db;

        public SahiplerController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index(string search)
        {
            var sahipler = db.Sahipler.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                sahipler = sahipler.Where(x =>
                    x.AdSoyad.Contains(search) ||
                    x.Telefon.Contains(search) ||
                    x.Email.Contains(search));
            }

            ViewBag.Search = search;

            return View(sahipler.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Sahipler sahip)
        {
            db.Sahipler.Add(sahip);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var sahip = db.Sahipler.Find(id);

            if (sahip == null)
            {
                return NotFound();
            }

            return View(sahip);
        }

        [HttpPost]
        public IActionResult Edit(Sahipler sahip)
        {
            db.Sahipler.Update(sahip);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var sahip = db.Sahipler.Find(id);

            if (sahip == null)
            {
                return NotFound();
            }

            db.Sahipler.Remove(sahip);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}