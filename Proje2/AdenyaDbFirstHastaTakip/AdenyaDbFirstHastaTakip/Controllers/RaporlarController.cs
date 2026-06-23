using AdenyaDbFirstHastaTakip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdenyaDbFirstHastaTakip.Controllers
{
    public class RaporlarController : Controller
    {
        private readonly AppDbContext db;

        public RaporlarController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            ViewBag.TurRaporu = db.Hayvanlar
                .GroupBy(x => x.Tur)
                .Select(x => new
                {
                    Tur = x.Key,
                    Sayi = x.Count()
                })
                .ToList();

            ViewBag.VeterinerTedaviRaporu = db.Tedaviler
    .Include(x => x.Veteriner)
    .GroupBy(x => x.Veteriner.AdSoyad)
    .Select(x => new
    {
        Veteriner = x.Key,
        TedaviSayisi = x.Count()
    })
    .ToList();



            ViewBag.YaklasanAsilar = db.Asilar
    .Include(x => x.Hayvan)
    .Where(x => x.SonrakiAsiTarihi >= DateTime.Today)
    .OrderBy(x => x.SonrakiAsiTarihi)
    .ToList();

            ViewBag.OdenmemisTedaviler = db.Tedaviler
                .Include(x => x.Hayvan)
                .Include(x => x.Veteriner)
                .Where(x => x.OdendiMi == false)
                .ToList();

            ViewBag.SonOtuzGunTedaviler = db.Tedaviler
                .Include(x => x.Hayvan)
                .Include(x => x.Veteriner)
                .Where(x => x.TedaviTarihi >= DateTime.Today.AddDays(-30))
                .OrderByDescending(x => x.TedaviTarihi)
                .ToList();
            return View();
        }
    }
}