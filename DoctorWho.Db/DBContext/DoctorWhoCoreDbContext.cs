using DoctorWho.Db.Configurations;
using DoctorWho.Db.Model;
using DoctorWho.Db.ModelCreating;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Context
{
    public class DoctorWhoCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddDoctorWhoConfiguration();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.CreationModel();

            modelBuilder.HasDbFunction(typeof(DoctorWhoCoreDbContext).GetMethod(nameof(FnCompanions), new[] { typeof(int) }))
                    .HasName("fnEnemies");
            modelBuilder.HasDbFunction(typeof(DoctorWhoCoreDbContext).GetMethod(nameof(FnEnemies), new[] { typeof(int) }))
                    .HasName("fnCompanions");
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<EpisodeCompanion> EpisodeCompanions { get; set; }
        public DbSet<EpisodeEnemy> EpisodeEnemies { get; set; }
        public DbSet<ViewEpisodes> ViewEpisodes { get; set; }

        public string FnCompanions(int EpisodeId) => throw new NotSupportedException();
        public string FnEnemies(int EpisodeId) => throw new NotSupportedException();
    }
}
