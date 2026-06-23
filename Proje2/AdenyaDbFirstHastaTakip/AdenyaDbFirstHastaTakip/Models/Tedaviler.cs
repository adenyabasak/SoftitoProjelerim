namespace AdenyaDbFirstHastaTakip.Models
{
    public class Tedaviler
    {
        public int Id { get; set; }

        public int HayvanId { get; set; }

        public int VeterinerId { get; set; }

        public string TedaviAdi { get; set; }

        public string? Aciklama { get; set; }

        public DateTime TedaviTarihi { get; set; }

        public decimal Ucret { get; set; }

        public bool OdendiMi { get; set; }

        public Hayvanlar? Hayvan { get; set; }

        public Veterinerler? Veteriner { get; set; }
    }
}