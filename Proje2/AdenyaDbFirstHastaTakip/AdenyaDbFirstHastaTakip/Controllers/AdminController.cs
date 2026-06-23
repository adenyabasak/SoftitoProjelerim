using AdenyaDbFirstHastaTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdenyaDbFirstHastaTakip.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext db;

        public AdminController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            ViewBag.SahipSayisi = db.Sahipler.Count();
            ViewBag.HayvanSayisi = db.Hayvanlar.Count();
            ViewBag.VeterinerSayisi = db.Veterinerler.Count();
            ViewBag.TedaviSayisi = db.Tedaviler.Count();
            ViewBag.AsiSayisi = db.Asilar.Count();
            ViewBag.RandevuSayisi = db.Randevular.Count();

            return View();
        }
    }
}