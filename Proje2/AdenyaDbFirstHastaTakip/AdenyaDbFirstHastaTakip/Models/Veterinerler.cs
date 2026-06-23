namespace AdenyaDbFirstHastaTakip.Models
{
    public class Veterinerler
    {
        public int Id { get; set; }

        public string AdSoyad { get; set; }

        public string? Uzmanlik { get; set; }

        public string? Telefon { get; set; }

        public string? Email { get; set; }

        public List<Tedaviler> Tedaviler { get; set; } = new List<Tedaviler>();

        public List<Randevular> Randevular { get; set; } = new List<Randevular>();
    }
}