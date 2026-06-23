namespace AdenyaDbFirstHastaTakip.Models
{
    public class Hayvanlar
    {
        public int Id { get; set; }

        public string HayvanAdi { get; set; }

        public string Tur { get; set; }

        public string? Irk { get; set; }

        public int? Yas { get; set; }

        public string? Cinsiyet { get; set; }

        public int SahipId { get; set; }

        public Sahipler? Sahip { get; set; }

        public List<Tedaviler> Tedaviler { get; set; } = new List<Tedaviler>();

        public List<Asilar> Asilar { get; set; } = new List<Asilar>();

        public List<Randevular> Randevular { get; set; } = new List<Randevular>();
    }
}