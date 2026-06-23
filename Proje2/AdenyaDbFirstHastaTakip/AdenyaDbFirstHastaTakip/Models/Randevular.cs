namespace AdenyaDbFirstHastaTakip.Models
{
    public class Randevular
    {
        public int Id { get; set; }

        public int HayvanId { get; set; }

        public int VeterinerId { get; set; }

        public DateTime RandevuTarihi { get; set; }

        public string RandevuDurumu { get; set; }

        public string? Notlar { get; set; }

        public Hayvanlar? Hayvan { get; set; }

        public Veterinerler? Veteriner { get; set; }
    }
}