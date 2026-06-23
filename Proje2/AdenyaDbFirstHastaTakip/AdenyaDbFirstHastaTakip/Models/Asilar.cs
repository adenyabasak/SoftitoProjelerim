namespace AdenyaDbFirstHastaTakip.Models
{
    public class Asilar
    {
        public int Id { get; set; }

        public int HayvanId { get; set; }

        public string AsiAdi { get; set; }

        public DateTime AsiTarihi { get; set; }

        public DateTime? SonrakiAsiTarihi { get; set; }

        public string? Aciklama { get; set; }

        public Hayvanlar? Hayvan { get; set; }
    }
}