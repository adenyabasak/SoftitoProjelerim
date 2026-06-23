using System.Collections.Generic;

namespace AdenyaDbFirstHastaTakip.Models
{
    public class Sahipler
    {
        public int Id { get; set; }

        public string AdSoyad { get; set; }

        public string Telefon { get; set; }

        public string? Email { get; set; }

        public string? Adres { get; set; }

        public List<Hayvanlar> Hayvanlar { get; set; } = new List<Hayvanlar>();
    }
}