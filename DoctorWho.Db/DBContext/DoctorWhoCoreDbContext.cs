using DoctorWho.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Context
{
    public class DoctorWhoCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ALI-J-BARGHOUTH;Initial Catalog=DoctorWhoCore;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enemy>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Author>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Companion>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Episode>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Enemy>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<EpisodeEnemy>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<EpisodeCompanion>()
                .HasKey(e => e.Id);
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<EpisodeCompanion> EpisodeCompanions { get; set; }
        public DbSet<EpisodeEnemy> EpisodeEnemies { get; set; }
    }
}
