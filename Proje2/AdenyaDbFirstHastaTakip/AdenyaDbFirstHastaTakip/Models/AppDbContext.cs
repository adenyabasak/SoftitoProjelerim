using Microsoft.EntityFrameworkCore;

namespace AdenyaDbFirstHastaTakip.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Sahipler> Sahipler { get; set; }
        public DbSet<Hayvanlar> Hayvanlar { get; set; }
        public DbSet<Veterinerler> Veterinerler { get; set; }
        public DbSet<Tedaviler> Tedaviler { get; set; }
        public DbSet<Asilar> Asilar { get; set; }
        public DbSet<Randevular> Randevular { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sahipler>().ToTable("Sahipler");
            modelBuilder.Entity<Hayvanlar>().ToTable("Hayvanlar");
            modelBuilder.Entity<Veterinerler>().ToTable("Veterinerler");
            modelBuilder.Entity<Tedaviler>().ToTable("Tedaviler");
            modelBuilder.Entity<Asilar>().ToTable("Asilar");
            modelBuilder.Entity<Randevular>().ToTable("Randevular");
        }
    }
}